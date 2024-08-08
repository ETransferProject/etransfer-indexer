using AeFinder.Sdk;
using AElf.Types;
using ETransfer.Contracts.TokenPool;
using ETransferIndexer.Entities;
using ETransferIndexer.GraphQL;
using ETransferIndexer.GraphQL.Input;
using Nethereum.Hex.HexConvertors.Extensions;
using Shouldly;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace ETransferIndexer.Processors;

public class TokenPoolReleaseProcessorTests: ETransferIndexerTestBase
{
    private readonly TokenPoolReleaseProcessor _tokenPoolReleaseProcessor;
    private readonly IReadOnlyRepository<TokenTransferIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    
    public TokenPoolReleaseProcessorTests()
    {
        _tokenPoolReleaseProcessor = GetRequiredService<TokenPoolReleaseProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<TokenTransferIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>();
    }

    [Fact]
    public async Task Test()
    {
        var logEvent = new TokenPoolReleased
        {
            From = Address.FromPublicKey("AAA".HexToByteArray()),
            To = Address.FromPublicKey("BBB".HexToByteArray()),
            Amount = 10,
            Symbol = "ELF"
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _tokenPoolReleaseProcessor.ProcessAsync(logEvent, logEventContext);

        var result = await Query.GetTokenPoolRecordListAsync(_repository, _objectMapper, new GetTokenTransferInput
        {
            TransactionIds = new List<string> { logEventContext.Transaction.TransactionId },
            StartBlockHeight = 1,
            EndBlockHeight = 200,
            SkipCount = 0,
            MaxResultCount = 10
        });
        result.TotalCount.ShouldBe(1);
        result.Data[0].ChainId.ShouldBe(logEventContext.ChainId);
        result.Data[0].BlockHash.ShouldBe(logEventContext.Block.BlockHash);
        result.Data[0].BlockHeight.ShouldBe(logEventContext.Block.BlockHeight);
    }
}