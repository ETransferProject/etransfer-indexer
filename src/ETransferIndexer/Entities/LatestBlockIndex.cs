using AeFinder.Sdk.Entities;

namespace ETransferIndexer.Entities;

public class LatestBlockIndex : AeFinderEntity, IAeFinderEntity
{
    public long BlockTime { get; set; }
    public bool Confirmed { get; set; }
}