using AeFinder.Sdk.Entities;
using Nest;

namespace ETransferIndexer.Entities;

public class ETransferTransactionIndex : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string TransactionId { get; set; }
    [Keyword] public string MethodName { get; set; }
    public long Timestamp { get; set; }
    public long Amount { get; set; }
    [Keyword] public string Symbol { get; set; }
    [Keyword] public string FromAddress { get; set; }
    [Keyword] public string ToAddress { get; set; }
    [Keyword] public string From { get; set; }
    [Keyword] public string To { get; set; }
    [Keyword] public string Params { get; set; }
    [Keyword] public string Signature { get; set; }
    public int Index { get; set; }
    public int Status { get; set; }
    [Keyword] public string Memo { get; set; }
}