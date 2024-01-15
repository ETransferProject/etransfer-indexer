using System.ComponentModel.DataAnnotations;

namespace ETransfer.Indexer.GraphQL.Dto;

public class GetLatestBlockInput
{
    [Required] public string ChainId { get; set; }
}