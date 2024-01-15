namespace ETransfer.Indexer.GraphQL.Dto;

public class TransactionListPageResultDto
{
    public long TotalCount { get; set; }
    public List<TransactionResultDto> Data { get; set; }
}

public class TransactionResultDto
{
    public string Id { get; set; }
    public string TransactionId { get; set; }
    public string MethodName { get; set; }
    public long Timestamp { get; set; }
    public string ChainId { get; set; }
    public string BlockHash { get; set; }
    public long Amount { get; set; }
    public string Symbol { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Params { get; set; }
    public string Signature { get; set; }
    public int Index { get; set; }
    public int Status { get; set; }
}