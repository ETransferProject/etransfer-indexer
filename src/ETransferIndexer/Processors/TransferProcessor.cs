using AeFinder.Sdk.Logging;
using AeFinder.Sdk.Processor;
using AElf.Contracts.MultiToken;
using ETransferIndexer.Entities;

namespace ETransferIndexer.Processors;

public class TransferProcessor : TransferProcessorBase<Transferred>
{
    public override async Task ProcessAsync(Transferred eventValue, LogEventContext context)
    {
        try
        {
            // only one data
            var latestBlock = new LatestBlockIndex
            {
                Id = context.ChainId,
                BlockTime = context.Block.BlockTime.ToUtcMilliSeconds()
            };
            await SaveEntityAsync(latestBlock);

            // filter by token pool account
            var tokenPoolContract = context.ChainId == ETransferConst.AELF 
                ? ETransferConst.TokenPoolAccountAddresses.Split(ETransferConst.Comma).ToList()
                : context.ChainId == ETransferConst.tDVV 
                    ? ETransferConst.TokenPoolAccountAddressesTDVV.Split(ETransferConst.Comma).ToList()
                    : ETransferConst.TokenPoolAccountAddressesTDVW.Split(ETransferConst.Comma).ToList();
            if (!tokenPoolContract.Contains(eventValue.From.ToBase58()) &&
                !tokenPoolContract.Contains(eventValue.To.ToBase58()))
            {
                return;
            }
            
            // Logger.LogInformation(
            //     "Transferred start, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}", context.Block.BlockHeight,
            //     context.Block.BlockHash,
            //     context.Transaction.TransactionId);

            var record = new ETransferTransactionIndex
            {
                TransactionId = context.Transaction.TransactionId,
                MethodName = context.Transaction.MethodName,
                Timestamp = context.Block.BlockTime.ToUtcMilliSeconds(),

                Amount = eventValue.Amount,
                Symbol = eventValue.Symbol,

                FromAddress = eventValue.From.ToBase58(),
                ToAddress = eventValue.To.ToBase58(),

                From = context.Transaction.From,
                To = context.Transaction.To,

                Params = context.Transaction.Params,
                Index = context.Transaction.Index,
                Status = (int)context.Transaction.Status,
                Memo = eventValue.Memo
            };
            
            record.Id = IdGenerateHelper.GetId(context.Block.BlockHash, context.Transaction.TransactionId);
            await SaveEntityAsync(record);
            // Logger.LogInformation(
            //     "Transferred end, blockHeight:{Height}, fromAddress:{FromAddress}, toAddress:{ToAddress}, from:{TxFrom}, to:{TxTo}",
            //     context.Block.BlockHeight, record.FromAddress, record.ToAddress, record.From, record.To);
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Transferred error, blockHeight:{Height}, blockHash:{Hash}, txId:{txId}",
                context.Block.BlockHeight, context.Block.BlockHash, context.Transaction.TransactionId);
        }
    }
}