using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using ETransfer.Contracts.TokenPool;
using Microsoft.Extensions.Logging;

namespace ETransfer.Indexer.Processors;

public class TokenSwapProcessor : TokenPoolProcessorBase<TokenSwapped>
{
    public TokenSwapProcessor(ILogger<AElfLogEventProcessorBase<TokenSwapped, LogEventInfo>> logger) : base(logger)
    {
    }

    protected override async Task HandleEventAsync(TokenSwapped eventValue, LogEventContext context)
    {
        var id = IdGenerateHelper.GetId(context.ChainId, eventValue.Channel);
        var swapTokenRecord = new Entities.TokenSwapRecordIndex()
        {
            Id = id,
            Timestamp = context.BlockTime,
            TransactionId = context.TransactionId,
            FromAddress = eventValue.From.ToBase58(),
            ToAddress = eventValue.To.ToBase58(),
            AmountOut = eventValue.AmountOut.AmountOut.Last()
        };
        
        ObjectMapper.Map(context, swapTokenRecord);
        ObjectMapper.Map(eventValue, swapTokenRecord);
        await TokenSwapRepository.AddOrUpdateAsync(swapTokenRecord);
    }
}