using AElf.CSharp.Core;
using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using ETransfer.Indexer.Entities;
using Volo.Abp.ObjectMapping;
using ETransfer.Indexer.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace ETransfer.Indexer.Processors;

public class TokenPoolProcessorBase<TEvent> : AElfLogEventProcessorBase<TEvent, LogEventInfo>
    where TEvent : IEvent<TEvent>, new()
{
    public TokenPoolProcessorBase(ILogger<AElfLogEventProcessorBase<TEvent, LogEventInfo>> logger) : base(logger)
    {
    }
    
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetRequiredService<IObjectMapper>();

    protected ContractInfoOptions ContractInfoOptions =>
        LazyServiceProvider.LazyGetRequiredService<IOptionsSnapshot<ContractInfoOptions>>().Value;
    
    protected ILogger<AElfLogEventProcessorBase<TEvent, LogEventInfo>> Logger => LazyServiceProvider
        .LazyGetRequiredService<ILogger<AElfLogEventProcessorBase<TEvent, LogEventInfo>>>();
    
    protected IAElfIndexerClientEntityRepository<TokenSwapRecordIndex, LogEventInfo> TokenSwapRepository => LazyServiceProvider
        .LazyGetRequiredService<IAElfIndexerClientEntityRepository<TokenSwapRecordIndex, LogEventInfo>>();


    public override string GetContractAddress(string chainId)
    {
        return ContractInfoOptions.ContractInfos.First(o => o.ChainId == chainId).TokenPoolContractAddress;
    }
}