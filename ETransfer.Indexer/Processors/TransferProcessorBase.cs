using AElf.CSharp.Core;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ETransfer.Indexer.Options;
using Volo.Abp.ObjectMapping;

namespace ETransfer.Indexer.Processors;

public class TransferProcessorBase<TEvent> : AElfLogEventProcessorBase<TEvent, TransactionInfo>
    where TEvent : IEvent<TEvent>, new()
{
    protected readonly ILogger<TransferProcessorBase<TEvent>> Logger;
    protected readonly IObjectMapper ObjectMapper;
    protected readonly ContractInfoOptions ContractInfoOptions;


    public TransferProcessorBase(ILogger<TransferProcessorBase<TEvent>> logger,
        IObjectMapper objectMapper,
        IOptionsSnapshot<ContractInfoOptions> contractInfoOptions) : base(logger)
    {
        Logger = logger;
        ObjectMapper = objectMapper;
        ContractInfoOptions = contractInfoOptions.Value;
    }

    public override string GetContractAddress(string chainId)
    {
        return ContractInfoOptions.ContractInfos.First(o => o.ChainId == chainId ).MultiTokenContractAddress;
    }
    
}