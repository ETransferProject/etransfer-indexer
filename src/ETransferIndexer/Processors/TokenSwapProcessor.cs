using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using ETransfer.Contracts.TokenPool;
using ETransferIndexer.Entities;

namespace ETransferIndexer.Processors;

public class TokenSwapProcessor : TokenPoolProcessorBase<TokenSwapped>
{
    public override async Task ProcessAsync(TokenSwapped eventValue, LogEventContext context)
    {
        try
        {
            Logger.LogInformation(
                "TokenSwapped start, chainId:{chainId}, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}",
                context.ChainId, context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
            var record = new TokenSwapRecordIndex
            {
                Id = IdGenerateHelper.GetId(context.ChainId, eventValue.Channel),
                Timestamp = context.Block.BlockTime.ToUtcMilliSeconds(),
                TransactionId = context.Transaction.TransactionId,
                FromAddress = eventValue.From.ToBase58(),
                ToAddress = eventValue.To.ToBase58(),
                SwapPath = eventValue.SwapPath.Path.ToList(),
                AmountOut = eventValue.AmountOut.AmountOut.Last()
            };

            ObjectMapper.Map(eventValue, record);
            await SaveEntityAsync(record);
            Logger.LogInformation(
                "TokenSwapped end, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}",
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "TokenSwapped error, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}",
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }
    }
}