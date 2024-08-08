using AeFinder.Sdk.Processor;
using ETransferIndexer.GraphQL;
using ETransferIndexer.Processors;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ETransferIndexer;

public class ETransferIndexerModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options => { options.AddMaps<ETransferIndexerModule>(); });
        context.Services.AddSingleton<ISchema, ETransferIndexerSchema>();
        context.Services.AddSingleton<ILogEventProcessor, TransferProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, TokenPoolTransferProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, TokenPoolReleaseProcessor>();
        context.Services.AddSingleton<ILogEventProcessor, TokenSwapProcessor>();
    }
}