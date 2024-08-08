using AeFinder.Sdk.Entities;
using Nest;

namespace ETransferIndexer.Entities;

public class TokenTransferIndex : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string TransactionId { get; set; }
    [Keyword] public string MethodName { get; set; }
    [Keyword] public string From { get; set; }
    [Keyword] public string To { get; set; }
    [Keyword] public string ToChainId { get; set; }
    [Keyword] public string ToAddress { get; set; }
    [Keyword] public string TransferType { get; set; }
    [Keyword] public string Symbol { get; set; }
    public long Amount { get; set; }
    public long MaxEstimateFee { get; set; }
    public long Timestamp { get; set; }
    public bool IsTransparent { get; set; }
    [Keyword] public string Memo { get; set; }
}