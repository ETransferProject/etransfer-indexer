using AeFinder.Sdk.Processor;
using AElf.CSharp.Core;
using Volo.Abp.ObjectMapping;

namespace ETransferIndexer.Processors;

public class TokenPoolProcessorBase<TEvent> : LogEventProcessorBase<TEvent> where TEvent : IEvent<TEvent>, new()
{
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetRequiredService<IObjectMapper>();
    
    public override async Task ProcessAsync(TEvent logEvent, LogEventContext context)
    {
    }

    public override string GetContractAddress(string chainId)
    {
        return chainId switch
        {
            ETransferConst.AELF => ETransferConst.TokenPoolContractAddress,
            ETransferConst.tDVV => ETransferConst.TokenPoolContractAddressTDVV,
            ETransferConst.tDVW => ETransferConst.TokenPoolContractAddressTDVW,
            _ => string.Empty
        };
    }
}