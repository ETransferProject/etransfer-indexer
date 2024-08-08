using AeFinder.Sdk.Entities;
using Nest;

namespace ETransferIndexer.Entities;

public class TokenSwapRecordIndex : AeFinderEntity, IAeFinderEntity
{
    [Keyword] public string TransactionId { get; set; }
    [Keyword] public string SymbolIn { get; set; }
    [Keyword] public string SymbolOut { get; set; }
    public long AmountIn { get; set; }
    public long AmountOut { get; set; }
    [Keyword] public string FromAddress { get; set; }
    [Keyword] public string ToAddress { get; set; }
    public List<string> SwapPath { get; set; }
    [Keyword] public string Channel { get; set; }
    public long FeeRate { get; set; }
    public long Timestamp { get; set; }
}