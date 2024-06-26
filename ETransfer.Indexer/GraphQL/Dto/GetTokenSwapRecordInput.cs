namespace ETransfer.Indexer.GraphQL.Dto;

public class GetTokenSwapRecordInput : PagedResultQueryInput
{
    public string ChainId { get; set; }
    public List<string> TransactionIds { get; set; }
    // order id
    public string Channel { get; set; }
    public long? StartBlockHeight { get; set; }
    public long? EndBlockHeight { get; set; }
    public long? TimestampMin { get; set; }
    public long? TimestampMax { get; set; }
}