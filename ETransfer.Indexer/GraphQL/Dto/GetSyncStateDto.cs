using AElfIndexer;

namespace ETransfer.Indexer.GraphQL.Dto;

public class GetSyncStateDto
{
    public string ChainId { get; set; }
    public BlockFilterType FilterType { get; set; }
}