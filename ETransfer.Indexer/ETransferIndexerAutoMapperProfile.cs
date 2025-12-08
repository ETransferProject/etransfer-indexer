using AElf.Contracts.MultiToken;
using AElfIndexer.Client.Handlers;
using AutoMapper;
using ETransfer.Contracts.TokenPool;
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
        CreateMap<LogEventContext, TokenTransferIndex>().ReverseMap();
        CreateMap<TokenPoolTransferred, TokenTransferIndex>().ReverseMap();
        CreateMap<TokenPoolReleased, TokenTransferIndex>().ReverseMap();
        CreateMap<TokenTransferIndex, TokenTransferResultDto>().ReverseMap();
        CreateMap<LogEventContext, TokenSwapRecordIndex>();
        CreateMap<TokenSwapped, TokenSwapRecordIndex>()
            .ForMember(d => d.SwapPath, opt => opt.MapFrom(s => s.SwapPath.Path.ToList()))
            .ForMember(d => d.AmountOut, opt => opt.MapFrom(s => s.AmountOut.AmountOut.Last()));
        CreateMap<TokenSwapRecordIndex, TokenSwapRecordDto>();
    }
}