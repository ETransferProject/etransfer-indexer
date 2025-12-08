using AElfIndexer.Client.GraphQL;

namespace ETransfer.Indexer.GraphQL.Dto;

public class ETransferIndexerSchema : AElfIndexerClientSchema<Query>
{
    public ETransferIndexerSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}