using AElf.Contracts.MultiToken;
using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Orleans.Runtime;
using ETransfer.Indexer.Entities;
using ETransfer.Indexer.Options;
using Volo.Abp.ObjectMapping;

namespace ETransfer.Indexer.Processors;

public class TransferProcessor : TransferProcessorBase<Transferred>
{
    protected readonly ContractInfoOptions ContractInfoOptions;

    protected readonly IAElfIndexerClientEntityRepository<ETransferTransactionIndex, LogEventInfo>
        TransferRecordIndexRepository;

    protected readonly IAElfIndexerClientEntityRepository<LatestBlockIndex, LogEventInfo>
        LatestBlockIndexRepository;

    public TransferProcessor(ILogger<TransferProcessor> logger,
        IObjectMapper objectMapper,
        IOptionsSnapshot<ContractInfoOptions> contractInfoOptions,
        IAElfIndexerClientEntityRepository<ETransferTransactionIndex, LogEventInfo> transferRecordIndexRepository,
        IAElfIndexerClientEntityRepository<LatestBlockIndex, LogEventInfo> latestBlockIndexRepository)
        : base(logger, objectMapper, contractInfoOptions)
    {
        TransferRecordIndexRepository = transferRecordIndexRepository;
        LatestBlockIndexRepository = latestBlockIndexRepository;
        ContractInfoOptions = contractInfoOptions.Value;
    }

    protected override async Task HandleEventAsync(Transferred eventValue, LogEventContext context)
    {
        try
        {
            Logger.Debug(
                "Received Transfer:blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", context.BlockHeight, context.BlockHash,
                context.TransactionId);

            // only one data
            var latestBlock = ObjectMapper.Map<LogEventContext, LatestBlockIndex>(context);
            latestBlock.Id = context.ChainId;
            await LatestBlockIndexRepository.AddOrUpdateAsync(latestBlock);

            // filter by token pool account
            var tokenPoolContract = ContractInfoOptions.ContractInfos
                .First(o => o.ChainId == context.ChainId).TokenPoolAccountAddresses;
            if (!tokenPoolContract.Contains(eventValue.From.ToBase58()) &&
                !tokenPoolContract.Contains(eventValue.To.ToBase58()))
            {
                return;
            }

            var record = new ETransferTransactionIndex()
            {
                ChainId = context.ChainId,
                TransactionId = context.TransactionId,
                MethodName = context.MethodName,
                Timestamp = DateTimeHelper.ToUnixTimeMilliseconds(context.BlockTime),

                BlockHash = context.BlockHash,
                Amount = eventValue.Amount,
                Symbol = eventValue.Symbol,

                FromAddress = eventValue.From.ToBase58(),
                ToAddress = eventValue.To.ToBase58(),

                From = context.From,
                To = context.To,

                Params = context.Params,
                Signature = context.Signature,
                Index = context.Index,
                Status = (int)context.Status,
                BlockHeight = context.BlockHeight
            };
            Logger.LogInformation(
                "Save blockHeight:{Height}, FromAddress:{FromAddress}, ToAddress:{ToAddress}, From:{TxFrom}, To:{TxTo}",
                record.BlockHeight, record.FromAddress, record.ToAddress, record.From, record.To);

            ObjectMapper.Map(eventValue, record);
            ObjectMapper.Map(context, record);
            record.Id = IdGenerateHelper.GetId(context.BlockHash, context.TransactionId);
            await TransferRecordIndexRepository.AddOrUpdateAsync(record);
        }
        catch (Exception e)
        {
            Logger.LogError( e, "TransferProcessor error: blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", context.BlockHeight, context.BlockHash,
                context.TransactionId);
        }

    }
}