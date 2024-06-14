using AElf.Indexing.Elasticsearch;
using AElfIndexer.Client;
using Nest;

namespace ETransfer.Indexer.Entities;

public class TokenTransferIndex : AElfIndexerClientEntity<string>, IIndexBuild
{
    [Keyword] public override string Id { get; set; }
    [Keyword] public string TransactionId { get; set; }
    [Keyword] public string MethodName { get; set; }
    [Keyword] public string From { get; set; }
    [Keyword] public string To { get; set; }
    [Keyword] public string ToChainId { get; set; }
    [Keyword] public string ToAddress { get; set; }
    [Keyword] public string TransferType { get; set; }
    public string Symbol { get; set; }
    public long Amount { get; set; }
    public long MaxEstimateFee { get; set; }
    public long Timestamp { get; set; }
    public bool IsTransparent { get; set; }
}