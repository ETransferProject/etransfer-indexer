using AeFinder.Sdk;
using AElf.Contracts.MultiToken;
using AElf.Types;
using ETransferIndexer.Entities;
using ETransferIndexer.GraphQL;
using ETransferIndexer.GraphQL.Input;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace ETransferIndexer.Processors;

public class TransferProcessorTests: ETransferIndexerTestBase
{
    private readonly TransferProcessor _transferProcessor;
    private readonly IReadOnlyRepository<ETransferTransactionIndex> _repository;
    private readonly IReadOnlyRepository<LatestBlockIndex> _latestBlockRepository;
    private readonly IObjectMapper _objectMapper;
    
    public TransferProcessorTests()
    {
        _transferProcessor = GetRequiredService<TransferProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<ETransferTransactionIndex>>();
        _latestBlockRepository = GetRequiredService<IReadOnlyRepository<LatestBlockIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>();
    }

    [Fact]
    public async Task Test()
    {
        var logEvent = new Transferred
        {
            From = Address.FromBase58(ETransferConst.TokenPoolAccountAddresses.Split(",")[0]),
            To = Address.FromBase58(ETransferConst.TokenPoolAccountAddresses.Split(",")[0]),
            Amount = 10,
            Symbol = "ELF"
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _transferProcessor.ProcessAsync(logEvent, logEventContext);

        var result1 = await Query.GetLatestBlockAsync(_latestBlockRepository, _objectMapper, new GetLatestBlockInput());
        result1.ShouldBeNull();

        result1 = await Query.GetLatestBlockAsync(_latestBlockRepository, _objectMapper, new GetLatestBlockInput
        {
            ChainId = "AELF"
        });
        result1.ChainId.ShouldBe("AELF");
        result1.BlockHeight.ShouldBe(logEventContext.Block.BlockHeight);
        
        var result2 = await Query.GetTransactionListAsync(_repository, _objectMapper, new GetTransactionListInput
        {
            TransactionIds = new List<string> { logEventContext.Transaction.TransactionId },
            StartBlockHeight = 1,
            EndBlockHeight = 200,
            SkipCount = 0,
            MaxResultCount = 10
        });
        result2.TotalCount.ShouldBe(1);
        result2.Data[0].ChainId.ShouldBe(logEventContext.ChainId);
        result2.Data[0].BlockHash.ShouldBe(logEventContext.Block.BlockHash);
        result2.Data[0].BlockHeight.ShouldBe(logEventContext.Block.BlockHeight);
    }
}