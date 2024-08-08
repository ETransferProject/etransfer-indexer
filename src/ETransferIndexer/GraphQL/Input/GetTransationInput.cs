namespace ETransferIndexer.GraphQL.Input;

public class GetTransactionListInput : PagedResultQueryInput
{
    public List<string> TransactionIds { get; set; }
    public long StartBlockHeight { get; set; }
    public long EndBlockHeight { get; set; }
}