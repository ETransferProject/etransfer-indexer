using AElf.Indexing.Elasticsearch;
using AElfIndexer.Client;

namespace ETransfer.Indexer.Entities;

public class LatestBlockIndex : AElfIndexerClientEntity<string>, IIndexBuild
{
    public long BlockTime { get; set; }

    public bool Confirmed { get; set; }

}