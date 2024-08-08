using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using ETransfer.Contracts.TokenPool;
using ETransferIndexer.Entities;

namespace ETransferIndexer.Processors;

public class TokenPoolReleaseProcessor : TokenPoolProcessorBase<TokenPoolReleased>
{
    public override async Task ProcessAsync(TokenPoolReleased eventValue, LogEventContext context)
    {
        try
        {
            Logger.LogInformation(
                "TokenPoolReleased start, chainId:{chainId}, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.ChainId, context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);

            var record = new TokenTransferIndex
            {
                TransactionId = context.Transaction.TransactionId,
                MethodName = context.Transaction.MethodName,
                Timestamp = context.Block.BlockTime.ToUtcMilliSeconds(),
                TransferType = TokenTransferType.Out.ToString()
            };

            ObjectMapper.Map(eventValue, record);
            record.From = eventValue.From.ToBase58();
            record.To = eventValue.To.ToBase58();
            record.Id = IdGenerateHelper.GetId(context.ChainId, context.Block.BlockHash, context.Transaction.TransactionId);
            await SaveEntityAsync(record);
            Logger.LogInformation(
                "TokenPoolReleased end, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "TokenPoolReleased error, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }
    }
}