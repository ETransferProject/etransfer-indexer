using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using ETransfer.Contracts.TokenPool;
using Microsoft.Extensions.Logging;
using ETransfer.Indexer.Entities;

namespace ETransfer.Indexer.Processors;

public class TokenPoolTransferProcessor : TokenPoolProcessorBase<TokenPoolTransferred>
{
    public TokenPoolTransferProcessor(ILogger<AElfLogEventProcessorBase<TokenPoolTransferred, LogEventInfo>> logger): base(logger)
    {
    }

    protected override async Task HandleEventAsync(TokenPoolTransferred eventValue, LogEventContext context)
    {
        try
        {
            Logger.LogInformation(
                "TokenPoolTransferred start: chainId:{chainId}, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.ChainId, context.BlockHeight, context.BlockHash, context.TransactionId);

            var record = new TokenTransferIndex
            {
                Timestamp = DateTimeHelper.ToUnixTimeMilliseconds(context.BlockTime),
                TransferType = TokenTransferType.In.ToString()
            };

            ObjectMapper.Map(eventValue, record);
            ObjectMapper.Map(context, record);
            record.From = eventValue.From.ToBase58();
            record.To = eventValue.To.ToBase58();
            record.IsTransparent = !eventValue.ToChainId.IsNullOrEmpty() && !eventValue.ToAddress.IsNullOrEmpty();
            record.Id = IdGenerateHelper.GetId(context.ChainId, context.BlockHash, context.TransactionId);
            await TokenTransferIndexRepository.AddOrUpdateAsync(record);
            Logger.LogInformation(
                "TokenPoolTransferred end: blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.BlockHeight, context.BlockHash, context.TransactionId);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "TokenPoolTransferred error: blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", 
                context.BlockHeight, context.BlockHash, context.TransactionId);
        }

    }
}