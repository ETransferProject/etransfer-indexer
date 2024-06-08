using AElf.Indexing.Elasticsearch;
using AElfIndexer.Client;
using ETransfer.Contracts.TokenPool;
using Nest;

namespace ETransfer.Indexer.Entities;

public class TokenSwapRecordIndex : AElfIndexerClientEntity<string>, IIndexBuild
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
    public DateTime Timestamp { get; set; }

}