using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using ETransfer.Contracts.TokenPool;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ETransfer.Indexer.Entities;
using ETransfer.Indexer.Options;
using Volo.Abp.ObjectMapping;

namespace ETransfer.Indexer.Processors;

public class TokenPoolTransferProcessor : TransferProcessorBase<TokenPoolTransferred>
{
    protected readonly ContractInfoOptions ContractInfoOptions;

    protected readonly IAElfIndexerClientEntityRepository<TokenTransferIndex, TransactionInfo> 
        TokenTransferIndexRepository;

    public TokenPoolTransferProcessor(ILogger<TokenPoolTransferProcessor> logger,
        IObjectMapper objectMapper,
        IOptionsSnapshot<ContractInfoOptions> contractInfoOptions,
        IAElfIndexerClientEntityRepository<TokenTransferIndex, TransactionInfo> tokenTransferIndexRepository)
        : base(logger, objectMapper, contractInfoOptions)
    {
        TokenTransferIndexRepository = tokenTransferIndexRepository;
        ContractInfoOptions = contractInfoOptions.Value;
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