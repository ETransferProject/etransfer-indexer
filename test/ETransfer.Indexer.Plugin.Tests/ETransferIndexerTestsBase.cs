using AElf.Types;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Client.Providers;
using AElfIndexer.Grains;
using AElfIndexer.Grains.State.Client;
using Nethereum.Hex.HexConvertors.Extensions;
using ETransfer.Indexer.TestBase;
using ETransfer.Indexer.Tests.Helper;

namespace ETransfer.Indexer.Tests;

public abstract class ETransferIndexerTestsBase : ETransferIndexerTestBase<ETransferIndexerTestsModule>
{
    private readonly IAElfIndexerClientInfoProvider _indexerClientInfoProvider;
    private readonly IBlockStateSetProvider<LogEventInfo> _blockStateSetLogEventInfoProvider;
    private readonly IBlockStateSetProvider<TransactionInfo> _blockStateSetTransactionInfoProvider;
    private readonly IDAppDataProvider _dAppDataProvider;
    private readonly IDAppDataIndexManagerProvider _dAppDataIndexManagerProvider;
    
    public ETransferIndexerTestsBase()
    {
        _indexerClientInfoProvider = GetRequiredService<IAElfIndexerClientInfoProvider>();
        _blockStateSetLogEventInfoProvider = GetRequiredService<IBlockStateSetProvider<LogEventInfo>>();
        _blockStateSetTransactionInfoProvider = GetRequiredService<IBlockStateSetProvider<TransactionInfo>>();
        _dAppDataProvider = GetRequiredService<IDAppDataProvider>();
        _dAppDataIndexManagerProvider = GetRequiredService<IDAppDataIndexManagerProvider>();
    }

    protected async Task<string> InitializeBlockStateSetAsync(BlockStateSet<LogEventInfo> blockStateSet,string chainId)
    {
        var key = GrainIdHelper.GenerateGrainId("BlockStateSets", _indexerClientInfoProvider.GetClientId(), chainId,
            _indexerClientInfoProvider.GetVersion());
        
        await _blockStateSetLogEventInfoProvider.SetBlockStateSetAsync(key,blockStateSet);
        await _blockStateSetLogEventInfoProvider.SetCurrentBlockStateSetAsync(key, blockStateSet);
        await _blockStateSetLogEventInfoProvider.SetLongestChainBlockStateSetAsync(key,blockStateSet.BlockHash);
        
        return key;
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
        var blockStateSet = new BlockStateSet<LogEventInfo>
        {
            BlockHash = logEventContext.BlockHash,
            BlockHeight = logEventContext.BlockHeight,
            Confirmed = true,
            PreviousBlockHash = logEventContext.PreviousBlockHash
        };
        return await InitializeBlockStateSetAsync(blockStateSet, logEventContext.ChainId);
    }


}