using ETransferIndexer.Entities;

namespace ETransferIndexer.GraphQL.Input;

public class GetTokenTransferInput : PagedResultQueryInput
{
    public List<string?>? TransactionIds { get; set; }
    public long StartBlockHeight { get; set; }
    public long EndBlockHeight { get; set; }
    public long TimestampMin { get; set; }
    public long TimestampMax { get; set; }
    public bool IsFilterEmpty { get; set; }
    public TokenTransferType TransferType { get; set; }
}