using ETransfer.Indexer.Entities;
using Volo.Abp.Application.Dtos;

namespace ETransfer.Indexer.GraphQL.Dto;

public class GetTokenTransferInput : PagedResultRequestDto
{
    public List<string> TransactionIds { get; set; }
    public long StartBlockHeight { get; set; }
    public long EndBlockHeight { get; set; }
    public long TimestampMin { get; set; }
    public long TimestampMax { get; set; }
    public bool IsFilterEmpty { get; set; }
    public TokenTransferType TransferType { get; set; }
}