namespace ETransfer.Indexer.GraphQL.Dto;

public class GetTokenSwapRecordInput : PagedResultQueryInput
{
    public string ChainId { get; set; }
    public string TransactionId { get; set; }
    public long? StartBlockHeight { get; set; }
    public long? EndBlockHeight { get; set; }
    public long? TimestampMin { get; set; }
    public long? TimestampMax { get; set; }
}