using AeFinder.Sdk;

namespace ETransferIndexer.GraphQL; 

public class ETransferIndexerSchema : AppSchema<Query>
{
    public ETransferIndexerSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}