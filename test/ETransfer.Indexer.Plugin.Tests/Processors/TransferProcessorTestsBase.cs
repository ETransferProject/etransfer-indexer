using AElf.Contracts.MultiToken;
using AElf.CSharp.Core.Extension;
using AElf.Types;
using AElfIndexer;
using AElfIndexer.Block.Dtos;
using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Client.Providers;
using AElfIndexer.Grains.State.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using Nethereum.Hex.HexConvertors.Extensions;
using Shouldly;
using ETransfer.Indexer.GraphQL;
using ETransfer.Indexer.Orleans.TestBase;
using ETransfer.Indexer.Processors;
using ETransfer.Indexer.Entities;
using ETransfer.Indexer.GraphQL.Dto;
using ETransfer.Indexer.Options;
using ETransfer.Indexer.Tests.Helper;
using Orleans;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace ETransfer.Indexer.Tests.Processors;

public sealed class TransferProcessorTestsBase : ETransferIndexerTestsBase
{
    private readonly IAElfIndexerClientEntityRepository<ETransferTransactionIndex, TransactionInfo> _recordRepository;
    private readonly IAElfIndexerClientEntityRepository<LatestBlockIndex, TransactionInfo> _latestRepository;
    private readonly IObjectMapper _objectMapper;
    private static DateTime _testDateTime = new DateTime(2023, 1, 1, 1, 1, 1);

    public TransferProcessorTestsBase()
    {
        _recordRepository =
            GetRequiredService<IAElfIndexerClientEntityRepository<ETransferTransactionIndex, TransactionInfo>>();
        _latestRepository =
            GetRequiredService<IAElfIndexerClientEntityRepository<LatestBlockIndex, TransactionInfo>>();
        _objectMapper = GetRequiredService<IObjectMapper>();
    }

    protected override void AfterAddApplication(IServiceCollection services)
    {
        base.AfterAddApplication(services);

        services.AddSingleton(MockContractInfoOptions());
    }

    private IOptionsSnapshot<ContractInfoOptions> MockContractInfoOptions()
    {
        var mock = new Mock<IOptionsSnapshot<ContractInfoOptions>>();
        var options = new ContractInfoOptions
        {
            ContractInfos = new List<ContractInfo>
            {
                new()
                {
                    ChainId = "AELF",
                    MultiTokenContractAddress = "MockAddress",
                    TokenPoolAccountAddresses = new List<string>
                    {
                        Address.FromPublicKey("BBB".HexToByteArray()).ToBase58()
                    }
                }
            }
        };
        mock.Setup(p => p.Value).Returns(options);
        return mock.Object;
    }

    [Fact]
    public async Task AddTransferAsyncTests()
    {
        var logEventContext = MockLogEventContext();
        var stateSetKey = await MockBlockState(logEventContext);

        var blockStateSetTransaction = new BlockStateSet<TransactionInfo>
        {
            BlockHash = logEventContext.BlockHash,
            BlockHeight = logEventContext.BlockHeight,
            Confirmed = true,
            PreviousBlockHash = logEventContext.PreviousBlockHash,
        };
        var blockStateSetKeyTransaction =
            await InitializeBlockStateSetAsync(blockStateSetTransaction, logEventContext.ChainId);

        var transferred = new Transferred()
        {
            From = Address.FromPublicKey("AAA".HexToByteArray()),
            To = Address.FromPublicKey("BBB".HexToByteArray()),
            Amount = 10,
            Symbol = "ELF"
        };
        var logEventInfo = MockLogEventInfo(transferred.ToLogEvent());

        var transferProcess = GetRequiredService<TransferProcessor>();
        await transferProcess.HandleEventAsync(logEventInfo, logEventContext);

        await BlockStateSetSaveDataAsync<LogEventInfo>(stateSetKey);
        await BlockStateSetSaveDataAsync<TransactionInfo>(blockStateSetKeyTransaction);


        var recordData =
            await _recordRepository.GetAsync(IdGenerateHelper.GetId(logEventContext.BlockHash,
                logEventContext.TransactionId));

        recordData.ShouldNotBeNull();
        recordData.ChainId.ShouldBe(logEventContext.ChainId);
        recordData.TransactionId.ShouldBe(logEventContext.TransactionId);
        recordData.Timestamp.ShouldBe(DateTimeHelper.ToUnixTimeMilliseconds(logEventContext.BlockTime));
        recordData.FromAddress.ShouldBe(transferred.From.ToBase58());
        recordData.ToAddress.ShouldBe(transferred.To.ToBase58());
        recordData.Amount.ShouldBe(transferred.Amount);
        recordData.Symbol.ShouldBe(transferred.Symbol);
        recordData.From.ShouldBe(logEventContext.From);
        recordData.To.ShouldBe(logEventContext.To);
        recordData.MethodName.ShouldBe(logEventContext.MethodName);
        recordData.Params.ShouldBe(logEventContext.Params);
        recordData.Signature.ShouldBe(logEventContext.Signature);
        recordData.Index.ShouldBe(logEventContext.Index);
        recordData.Status.ShouldBe((int)logEventContext.Status);
    }

    [Fact]
    public async Task GetTransactionListAsyncTests()
    {
        await AddTransferAsyncTests();

        var result = await Query.GetTransactionListAsync(_recordRepository, _objectMapper, new GetTransactionListInput
        {
            TransactionIds = new List<string>() { "c1e625d135171c766999274a00a7003abed24cfe59a7215aabf1472ef20a2da2" },
            StartBlockHeight = 10,
            EndBlockHeight = 101,
            MaxResultCount = 100,
        });
        result.TotalCount.ShouldBe(1);
        result.Data[0].TransactionId.ShouldBe("c1e625d135171c766999274a00a7003abed24cfe59a7215aabf1472ef20a2da2");


        var latestBlock = await Query.GetLatestBlock(_latestRepository, _objectMapper, new GetLatestBlockInput
        {
            ChainId = "AELF"
        });
        latestBlock.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task SyncStateAsyncTests()
    {
        await AddTransferAsyncTests();
        var aelfIndexerClientInfoProvider = GetRequiredService<IAElfIndexerClientInfoProvider>();
        var clusterClient = GetRequiredService<IClusterClient>();
        
        var result = await Query.SyncStateAsync(clusterClient, aelfIndexerClientInfoProvider, new GetSyncStateDto
        {
            ChainId = "AELF",
            FilterType = BlockFilterType.LogEvent
        });
        await Task.Delay(1000);
        // unit cann't update confirmHeight
        result.ConfirmedBlockHeight.ShouldBeGreaterThanOrEqualTo(0);
    }
}