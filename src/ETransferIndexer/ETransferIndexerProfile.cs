using ETransferIndexer.Entities;
using AutoMapper;
using ETransfer.Contracts.TokenPool;
using ETransferIndexer.GraphQL.Dto;

namespace ETransferIndexer;

public class ETransferIndexerProfile : Profile
{
    public ETransferIndexerProfile()
    {
        CreateMap<TokenPoolReleased, TokenTransferIndex>();
        CreateMap<TokenPoolTransferred, TokenTransferIndex>();
        CreateMap<TokenSwapped, TokenSwapRecordIndex>()
            .ForMember(d => d.SwapPath, opt => opt.MapFrom(s => s.SwapPath.Path.ToList()))
            .ForMember(d => d.AmountOut, opt => opt.MapFrom(s => s.AmountOut.AmountOut.Last()));
        CreateMap<LatestBlockIndex, LatestBlockDto>()
            .ForMember(res => res.ChainId, opt => opt.MapFrom(res => res.Metadata.ChainId))
            .ForMember(res => res.BlockHash, opt => opt.MapFrom(res => res.Metadata.Block.BlockHash))
            .ForMember(res => res.BlockHeight, opt => opt.MapFrom(res => res.Metadata.Block.BlockHeight));
        CreateMap<ETransferTransactionIndex, TransactionResultDto>()
            .ForMember(res => res.ChainId, opt => opt.MapFrom(res => res.Metadata.ChainId))
            .ForMember(res => res.BlockHash, opt => opt.MapFrom(res => res.Metadata.Block.BlockHash))
            .ForMember(res => res.BlockHeight, opt => opt.MapFrom(res => res.Metadata.Block.BlockHeight));
        CreateMap<TokenTransferIndex, TokenTransferResultDto>()
            .ForMember(res => res.ChainId, opt => opt.MapFrom(res => res.Metadata.ChainId))
            .ForMember(res => res.BlockHash, opt => opt.MapFrom(res => res.Metadata.Block.BlockHash))
            .ForMember(res => res.BlockHeight, opt => opt.MapFrom(res => res.Metadata.Block.BlockHeight));
        CreateMap<TokenSwapRecordIndex, TokenSwapRecordDto>()
            .ForMember(res => res.ChainId, opt => opt.MapFrom(res => res.Metadata.ChainId))
            .ForMember(res => res.BlockHash, opt => opt.MapFrom(res => res.Metadata.Block.BlockHash))
            .ForMember(res => res.BlockHeight, opt => opt.MapFrom(res => res.Metadata.Block.BlockHeight))
            .ForMember(res => res.BlockTime, opt => opt.MapFrom(res => res.Metadata.Block.BlockTime));
    }
}