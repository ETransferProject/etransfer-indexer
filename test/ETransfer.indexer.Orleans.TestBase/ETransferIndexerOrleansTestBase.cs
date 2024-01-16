using Orleans.TestingHost;
using ETransfer.Indexer.TestBase;
using Volo.Abp.Modularity;

namespace ETransfer.Indexer.Orleans.TestBase;

public abstract class ETransferIndexerOrleansTestBase<TStartupModule> : ETransferIndexerTestBase<TStartupModule> 
    where TStartupModule : IAbpModule
{
    protected readonly TestCluster Cluster;

    public ETransferIndexerOrleansTestBase()
    {
        Cluster = GetRequiredService<ClusterFixture>().Cluster;
    }
}