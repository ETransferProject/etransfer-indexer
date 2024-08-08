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

public class TokenSwapProcessorTests: ETransferIndexerTestBase
{
    private readonly TokenSwapProcessor _tokenSwapProcessor;
    private readonly IReadOnlyRepository<TokenSwapRecordIndex> _repository;
    private readonly IObjectMapper _objectMapper;
    
    public TokenSwapProcessorTests()
    {
        _tokenSwapProcessor = GetRequiredService<TokenSwapProcessor>();
        _repository = GetRequiredService<IReadOnlyRepository<TokenSwapRecordIndex>>();
        _objectMapper = GetRequiredService<IObjectMapper>();
    }

    [Fact]
    public async Task Test()
    {
        var logEvent = new TokenSwapped
        {
            SymbolIn = "USDT",
            SymbolOut = "TEST1",
            AmountIn = 10000,
            AmountOut = new AmountsOut
            {
                AmountOut = { 900, 800 }
            },
            Channel = "Order",
            From = Address.FromPublicKey("AAA".HexToByteArray()),
            To = Address.FromPublicKey("BBB".HexToByteArray()),
            SwapPath = new SwapPath
            {
                Path = { "USDT", "TEST", "TEST1" }
            },
            FeeRate = 300
        };
        var logEventContext = GenerateLogEventContext(logEvent);
        await _tokenSwapProcessor.ProcessAsync(logEvent, logEventContext);

        var result = await Query.GetSwapTokenRecordAsync(_repository, _objectMapper, new GetTokenSwapRecordInput
        {
            ChainId = "AELF",
            TransactionIds = new List<string> { logEventContext.Transaction.TransactionId },
            Channel = "Order",
            StartBlockHeight = 1,
            EndBlockHeight = 200,
            TimestampMin = DateTime.UtcNow.AddDays(-1).ToUtcMilliSeconds(),
            TimestampMax = DateTime.UtcNow.AddDays(1).ToUtcMilliSeconds(),
            SkipCount = 0,
            MaxResultCount = 10
        });
        result.TotalCount.ShouldBe(1);
        result.Data[0].ChainId.ShouldBe(logEventContext.ChainId);
        result.Data[0].BlockHash.ShouldBe(logEventContext.Block.BlockHash);
        result.Data[0].BlockHeight.ShouldBe(logEventContext.Block.BlockHeight);
    }
}