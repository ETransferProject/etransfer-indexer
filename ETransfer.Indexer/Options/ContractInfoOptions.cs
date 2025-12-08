namespace ETransfer.Indexer.Options;

public class ContractInfoOptions
{
    public List<ContractInfo> ContractInfos { get; set; }
}

public class ContractInfo
{
    public string ChainId { get; set; }
    public string MultiTokenContractAddress { get; set; }
    public string TokenPoolContractAddress { get; set; }

    public List<string> TokenPoolAccountAddresses { get; set; }
}