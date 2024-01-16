using AElf.Indexing.Elasticsearch;
using AElfIndexer.Client;
using Nest;

namespace ETransfer.Indexer.Entities;

public class ETransferTransactionIndex : AElfIndexerClientEntity<string>, IIndexBuild
{
    [Keyword] public override string Id { get; set; }
    [Keyword] public string TransactionId { get; set; }
    [Keyword] public string MethodName { get; set; }
    public long Timestamp { get; set; }

    public long Amount { get; set; }

    public string Symbol { get; set; }
    [Keyword] public string FromAddress { get; set; }

    [Keyword] public string ToAddress { get; set; }


    public string From { get; set; }

    public string To { get; set; }


    public string Params { get; set; }

    public string Signature { get; set; }

    public int Index { get; set; }

    public int Status { get; set; }
}