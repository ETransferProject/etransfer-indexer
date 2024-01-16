using AElf.Contracts.MultiToken;
using AElfIndexer.Client.Handlers;
using AutoMapper;
using ETransfer.Indexer.Entities;
using ETransfer.Indexer.GraphQL.Dto;

namespace ETransfer.Indexer;

public class ETransferIndexerAutoMapperProfile : Profile
{
    public ETransferIndexerAutoMapperProfile()
    {
        CreateMap<LogEventContext, ETransferTransactionIndex>().ReverseMap();
        CreateMap<Transferred, ETransferTransactionIndex>().ReverseMap();
        CreateMap<ETransferTransactionIndex, TransactionResultDto>().ReverseMap();
        CreateMap<LogEventContext, LatestBlockIndex>()
            .ForMember(res => res.BlockTime, opt => opt.MapFrom(res => res.BlockTime.ToUtcMilliSeconds()))
            .ReverseMap();
        CreateMap<LatestBlockDto, LatestBlockIndex>().ReverseMap();
    }
}