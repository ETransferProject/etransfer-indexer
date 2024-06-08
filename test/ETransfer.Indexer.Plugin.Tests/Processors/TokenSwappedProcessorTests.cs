using AElf.Types;
using ETransfer.Contracts.TokenPool;
using Xunit;
using ETransfer.Indexer.GraphQL;
using ETransfer.Indexer.GraphQL.Dto;
using Shouldly;

namespace ETransfer.Indexer.Tests.Processors;

public class TokenSwappedProcessorTests : ETransferIndexerTestsBase
{
    [Fact]
    public async Task TokenSwapTest()
    {
        await CreateTokenSwapEventAsync();
        var swapRecord = await Query.GetSwapTokenRecord(TokenSwapRecordRepository, ObjectMapper,
            new GetTokenSwapRecordInput
            {
                ChainId = "AELF"
            });
        swapRecord.TotalCount.ShouldBe(1);
        swapRecord.Items[0].SymbolIn.ShouldBe("USDT");
        swapRecord.Items[0].SymbolOut.ShouldBe("TEST1");
        swapRecord.Items[0].AmountIn.ShouldBe(10000);
        swapRecord.Items[0].AmountOut.ShouldBe(800);
        swapRecord.Items[0].SwapPath.Count.ShouldBe(3);
        swapRecord.Items[0].SwapPath[0].ShouldBe("USDT");
        swapRecord.Items[0].SwapPath[1].ShouldBe("TEST");
        swapRecord.Items[0].SwapPath[2].ShouldBe("TEST1");
        swapRecord.Items[0].Channel.ShouldBe("Order");
        swapRecord.Items[0].FromAddress.ShouldBe(TestAddress.ToBase58());
        swapRecord.Items[0].ToAddress.ShouldBe(TestAddress1.ToBase58());
        swapRecord.Items[0].FeeRate.ShouldBe(300);
    }

    private async Task CreateTokenSwapEventAsync()
    {
        var tokenSwapped = new TokenSwapped
        {
            SymbolIn = "USDT",
            SymbolOut = "TEST1",
            AmountIn = 10000,
            AmountOut = new AmountsOut
            {
                AmountOut = { 900, 800 }
            },
            Channel = "Order",
            From = TestAddress,
            To = TestAddress1,
            SwapPath = new SwapPath
            {
                Path = { "USDT", "TEST", "TEST1" }
            },
            FeeRate = 300
        };
        var logEventInfo = GenerateLogEventInfo(tokenSwapped);
        var logEventContext = GenerateLogEventContext();

        await TokenSwapProcessor.HandleEventAsync(logEventInfo, logEventContext);
        await SaveDataAsync();
    }
}