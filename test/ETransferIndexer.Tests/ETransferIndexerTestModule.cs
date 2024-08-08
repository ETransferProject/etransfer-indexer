using AeFinder.App.TestBase;
using ETransferIndexer.Processors;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ETransferIndexer;

[DependsOn(
    typeof(AeFinderAppTestBaseModule),
    typeof(ETransferIndexerModule))]
public class ETransferIndexerTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AeFinderAppEntityOptions>(options => { options.AddTypes<ETransferIndexerModule>(); });
        
        // Add your Processors.
        context.Services.AddSingleton<TransferProcessor>();
        context.Services.AddSingleton<TokenPoolReleaseProcessor>();
        context.Services.AddSingleton<TokenPoolTransferProcessor>();
        context.Services.AddSingleton<TokenSwapProcessor>();
    }
}