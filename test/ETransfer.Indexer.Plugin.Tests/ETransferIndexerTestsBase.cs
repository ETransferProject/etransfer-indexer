using AElf.CSharp.Core;
using AElf.CSharp.Core.Extension;
using AElf.Types;
using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Client.Providers;
using AElfIndexer.Grains;
using AElfIndexer.Grains.State.Client;
using ETransfer.Indexer.Entities;
using ETransfer.Indexer.Processors;
using Nethereum.Hex.HexConvertors.Extensions;
using ETransfer.Indexer.TestBase;
using ETransfer.Indexer.Tests.Helper;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Threading;

namespace ETransfer.Indexer.Tests;

public abstract class ETransferIndexerTestsBase : ETransferIndexerTestBase<ETransferIndexerTestsModule>
{
    private readonly IAElfIndexerClientInfoProvider _indexerClientInfoProvider;
    private readonly IBlockStateSetProvider<LogEventInfo> _blockStateSetLogEventInfoProvider;
    private readonly IBlockStateSetProvider<TransactionInfo> _blockStateSetTransactionInfoProvider;
    private readonly IDAppDataProvider _dAppDataProvider;
    private readonly IDAppDataIndexManagerProvider _dAppDataIndexManagerProvider;
    protected readonly IObjectMapper ObjectMapper;
    protected readonly TokenSwapProcessor TokenSwapProcessor;
    protected readonly IAElfIndexerClientEntityRepository<TokenSwapRecordIndex, TransactionInfo> TokenSwapRecordRepository;
    protected Address TestAddress = Address.FromBase58("ooCSxQ7zPw1d4rhQPBqGKB6myvuWbicCiw3jdcoWEMMpa54ea");
    protected Address TestAddress1 = Address.FromBase58("nn659b9X1BLhnu5RWmEUbuuV7J9QKVVSN54j9UmeCbF3Dve5D");
    protected string ChainId = "AELF";
    protected string BlockHash = "dac5cd67a2783d0a3d843426c2d45f1178f4d052235a907a0d796ae4659103b1";
    protected string PreviousBlockHash = "e38c4fb1cf6af05878657cb3f7b5fc8a5fcfb2eec19cd76b73abb831973fbf4e";
    protected string TransactionId = "c1e625d135171c766999274a00a7003abed24cfe59a7215aabf1472ef20a2da2";
    protected long BlockHeight = 100;
    protected string BlockStateSetKey;

    
    public ETransferIndexerTestsBase()
    {
        _indexerClientInfoProvider = GetRequiredService<IAElfIndexerClientInfoProvider>();
        _blockStateSetLogEventInfoProvider = GetRequiredService<IBlockStateSetProvider<LogEventInfo>>();
        _blockStateSetTransactionInfoProvider = GetRequiredService<IBlockStateSetProvider<TransactionInfo>>();
        _dAppDataProvider = GetRequiredService<IDAppDataProvider>();
        _dAppDataIndexManagerProvider = GetRequiredService<IDAppDataIndexManagerProvider>();
        TokenSwapProcessor = GetRequiredService<TokenSwapProcessor>();
        TokenSwapRecordRepository =
            GetRequiredService<IAElfIndexerClientEntityRepository<TokenSwapRecordIndex, TransactionInfo>>();
        BlockStateSetKey = AsyncHelper.RunSync(async () => await InitializeBlockStateSetAsync(
            new BlockStateSet<TransactionInfo>
            {
                BlockHash = BlockHash,
                BlockHeight = BlockHeight,
                Confirmed = true,
                PreviousBlockHash = PreviousBlockHash,
            }, ChainId));
        ObjectMapper = GetRequiredService<IObjectMapper>();
    }

    protected async Task<string> InitializeBlockStateSetAsync(BlockStateSet<TransactionInfo> blockStateSet,string chainId)
    {
        var key = GrainIdHelper.GenerateGrainId("BlockStateSets", _indexerClientInfoProvider.GetClientId(), chainId,
            _indexerClientInfoProvider.GetVersion());
        
        await _blockStateSetTransactionInfoProvider.SetBlockStateSetAsync(key,blockStateSet);
        await _blockStateSetTransactionInfoProvider.SetCurrentBlockStateSetAsync(key, blockStateSet);
        await _blockStateSetTransactionInfoProvider.SetLongestChainBlockStateSetAsync(key,blockStateSet.BlockHash);

        return key;
    }
    
    protected async Task BlockStateSetSaveDataAsync<TSubscribeType>(string key)
    {
        await _dAppDataProvider.SaveDataAsync();
        await _dAppDataIndexManagerProvider.SavaDataAsync();
        if(typeof(TSubscribeType) == typeof(TransactionInfo))
            await _blockStateSetTransactionInfoProvider.SaveDataAsync(key);
        else if(typeof(TSubscribeType) == typeof(LogEventInfo))
            await _blockStateSetLogEventInfoProvider.SaveDataAsync(key);
    }
    
    protected LogEventContext MockLogEventContext(string chainId = "AELF")
    {        
        const string blockHash = "dac5cd67a2783d0a3d843426c2d45f1178f4d052235a907a0d796ae4659103b1";
        const string previousBlockHash = "e38c4fb1cf6af05878657cb3f7b5fc8a5fcfb2eec19cd76b73abb831973fbf4e";
        const string transactionId = "c1e625d135171c766999274a00a7003abed24cfe59a7215aabf1472ef20a2da2";
        const long blockHeight = 100;

        return new LogEventContext
        {
            ChainId = chainId,
            BlockHeight = blockHeight,
            BlockHash = blockHash,
            BlockTime = DateTime.UtcNow,
            PreviousBlockHash = previousBlockHash,
            TransactionId = transactionId,
            From = Address.FromPublicKey("AA".HexToByteArray()).ToBase58(),
            To = Address.FromPublicKey("DD".HexToByteArray()).ToBase58()
        };
    }

    protected LogEventInfo MockLogEventInfo(LogEvent logEvent)
    {
        var logEventInfo = LogEventHelper.ConvertAElfLogEventToLogEventInfo(logEvent);
        var logEventContext = MockLogEventContext();
        logEventInfo.BlockHeight = logEventContext.BlockHeight;
        logEventInfo.ChainId = logEventContext.ChainId;
        logEventInfo.BlockHash = logEventContext.BlockHash;
        logEventInfo.TransactionId = logEventContext.TransactionId;
        return logEventInfo;
    }

    protected async Task<string> MockBlockState(LogEventContext logEventContext)
    {
        var blockStateSet = new BlockStateSet<TransactionInfo>
        {
            BlockHash = logEventContext.BlockHash,
            BlockHeight = logEventContext.BlockHeight,
            Confirmed = true,
            PreviousBlockHash = logEventContext.PreviousBlockHash
        };
        return await InitializeBlockStateSetAsync(blockStateSet, logEventContext.ChainId);
    }
    protected LogEventInfo GenerateLogEventInfo<T>(T eventData) where T : IEvent<T>
    {
        var logEventInfo = LogEventHelper.ConvertAElfLogEventToLogEventInfo(eventData.ToLogEvent());
        logEventInfo.BlockHeight = BlockHeight;
        logEventInfo.ChainId = ChainId;
        logEventInfo.BlockHash = BlockHash;
        logEventInfo.TransactionId = TransactionId;

        return logEventInfo;
    }
    
    protected LogEventContext GenerateLogEventContext()
    {
        return new LogEventContext
        {
            ChainId = ChainId,
            BlockHeight = BlockHeight,
            BlockHash = BlockHash,
            PreviousBlockHash = PreviousBlockHash,
            TransactionId = Guid.NewGuid().ToString("N"),
            BlockTime = DateTime.UtcNow
        };
    }

    protected async Task SaveDataAsync()
    {
        await _dAppDataProvider.SaveDataAsync();
        await _dAppDataIndexManagerProvider.SavaDataAsync();
        await _blockStateSetTransactionInfoProvider.SaveDataAsync(BlockStateSetKey);
    }

}