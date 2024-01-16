
namespace ETransfer.Indexer.GraphQL.Dto;

public class LatestBlockDto
{
    
    public string ChainId { get; set; }
    public string BlockHash { get; set; }
    public long BlockHeight { get; set; }
    public string PreviousBlockHash { get; set; }
    public long BlockTime { get; set; }
    public bool Confirmed { get; set; }

}