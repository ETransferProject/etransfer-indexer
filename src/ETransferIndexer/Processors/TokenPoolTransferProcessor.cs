using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using ETransfer.Contracts.TokenPool;
using ETransferIndexer.Entities;

namespace ETransferIndexer.Processors;

public class TokenPoolTransferProcessor : TokenPoolProcessorBase<TokenPoolTransferred>
{
    public override async Task ProcessAsync(TokenPoolTransferred eventValue, LogEventContext context)
    {
        try
        {
            Logger.LogInformation(
                "TokenPoolTransferred start, chainId:{chainId}, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.ChainId, context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);

            var record = new TokenTransferIndex
            {
                TransactionId = context.Transaction.TransactionId,
                MethodName = context.Transaction.MethodName,
                Timestamp = context.Block.BlockTime.ToUtcMilliSeconds(),
                TransferType = TokenTransferType.In.ToString()
            };
            
            ObjectMapper.Map(eventValue, record);
            record.From = eventValue.From.ToBase58();
            record.To = eventValue.To.ToBase58();
            record.IsTransparent = !eventValue.ToChainId.IsNullOrEmpty() && !eventValue.ToAddress.IsNullOrEmpty();
            record.Id = IdGenerateHelper.GetId(context.ChainId, context.Block.BlockHash, context.Transaction.TransactionId);
            await SaveEntityAsync(record);
            Logger.LogInformation(
                "TokenPoolTransferred end, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "TokenPoolTransferred error, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }

    }
}