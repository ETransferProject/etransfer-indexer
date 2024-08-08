using AeFinder.Sdk.Processor;
using AElf.CSharp.Core;

namespace ETransferIndexer.Processors;

public class TransferProcessorBase<TEvent> : LogEventProcessorBase<TEvent> where TEvent : IEvent<TEvent>, new()
{
    public override async Task ProcessAsync(TEvent logEvent, LogEventContext context)
    {
    }

    public override string GetContractAddress(string chainId)
    {
        return chainId switch
        {
            ETransferConst.AELF => ETransferConst.MultiTokenContractAddress,
            ETransferConst.tDVV => ETransferConst.MultiTokenContractAddressTDVV,
            ETransferConst.tDVW => ETransferConst.MultiTokenContractAddressTDVW,
            _ => string.Empty
        };
    }
}