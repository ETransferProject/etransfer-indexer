using AElfIndexer.Client;
using AElfIndexer.Client.Handlers;
using AElfIndexer.Grains.State.Client;
using Microsoft.Extensions.DependencyInjection;
using ETransfer.Indexer.Processors;
using ETransfer.Indexer.GraphQL;
using ETransfer.Indexer.GraphQL.Dto;
using ETransfer.Indexer.Handler;
using ETransfer.Indexer.Options;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ETransfer.Indexer;

[DependsOn(typeof(AElfIndexerClientModule))]
public class ETransferIndexerModule : AElfIndexerClientPluginBaseModule<ETransferIndexerModule, ETransferIndexerSchema, Query>
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<ETransferIndexerModule>(); });
        var configuration = serviceCollection.GetConfiguration();
        // serviceCollection.AddSingleton<IAElfDataProvider, AElfDataProvider>(); 
        serviceCollection.AddSingleton<IAElfLogEventProcessor<TransactionInfo>, TransferProcessor>();
        serviceCollection.AddSingleton<IBlockChainDataHandler, ETransferTransactionHandler>();
        Configure<ContractInfoOptions>(configuration.GetSection("ContractInfo"));
        Configure<NodeOptions>(configuration.GetSection("Node"));
    }

    protected override string ClientId => "Indexer_ETransfer";
    protected override string Version => "xxxx";
}