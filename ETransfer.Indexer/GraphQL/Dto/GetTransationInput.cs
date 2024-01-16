using Volo.Abp.Application.Dtos;

namespace ETransfer.Indexer.GraphQL.Dto;

public class GetTransactionListInput:PagedResultRequestDto
{
    public List<string> TransactionIds { get; set; }
    public long StartBlockHeight { get; set; }
    public long EndBlockHeight { get; set; }
}