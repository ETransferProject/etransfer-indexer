using AElfIndexer.Client;
using AElfIndexer.Client.Providers;
using AElfIndexer.Grains;
using AElfIndexer.Grains.Grain.Client;
using AElfIndexer.Grains.State.Client;
using GraphQL;
using Nest;
using ETransfer.Indexer.Entities;
using ETransfer.Indexer.GraphQL.Dto;
using Orleans;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace ETransfer.Indexer.GraphQL;

public class Query
{
    [Name("syncState")]
    public static async Task<SyncStateDto> SyncStateAsync(
        [FromServices] IClusterClient clusterClient, 
        [FromServices] IAElfIndexerClientInfoProvider clientInfoProvider,
        GetSyncStateDto input)
    {
        var version = clientInfoProvider.GetVersion();
        var clientId = clientInfoProvider.GetClientId();
        var blockStateSetInfoGrain =
            clusterClient.GetGrain<IBlockStateSetInfoGrain>(
                GrainIdHelper.GenerateGrainId("BlockStateSetInfo", clientId, input.ChainId, version));
        var confirmedHeight = await blockStateSetInfoGrain.GetConfirmedBlockHeight(input.FilterType);
        return new SyncStateDto
        {
            ConfirmedBlockHeight = confirmedHeight
        };
    }
    
    [Name("getLatestBlock")]
    public static async Task<LatestBlockDto> GetLatestBlock(
        [FromServices] IAElfIndexerClientEntityRepository<LatestBlockIndex, LogEventInfo> repository,
        [FromServices] IObjectMapper objectMapper,
        GetLatestBlockInput input
    )
    {
        var latestBlock = await repository.GetAsync(input.ChainId);
        if (latestBlock == null) return null;

        return objectMapper.Map<LatestBlockIndex, LatestBlockDto>(latestBlock);
    }

    [Name("getTransaction")]
    public static async Task<TransactionListPageResultDto> GetTransactionListAsync(
        [FromServices] IAElfIndexerClientEntityRepository<ETransferTransactionIndex, LogEventInfo> repository,
        [FromServices] IObjectMapper objectMapper,
        GetTransactionListInput input
    )
    {
        var mustQuery = new List<Func<QueryContainerDescriptor<ETransferTransactionIndex>, QueryContainer>>();
        mustQuery.Add(q => q.Terms(i
            => i.Field(f => f.TransactionId).Terms(input.TransactionIds)));

        if (input.StartBlockHeight > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.BlockHeight).GreaterThanOrEquals(input.StartBlockHeight)));
        }

        if (input.EndBlockHeight > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.BlockHeight).LessThanOrEquals(input.EndBlockHeight)));
        }

        QueryContainer Filter(QueryContainerDescriptor<ETransferTransactionIndex> f) =>
            f.Bool(b => b.Must(mustQuery));

        var result = await repository.GetListAsync(Filter,skip: input.SkipCount, limit: input.MaxResultCount);
        var txList = objectMapper.Map<List<ETransferTransactionIndex>, List<TransactionResultDto>>(result.Item2);
        return new TransactionListPageResultDto
        {
            TotalCount = result.Item1,
            Data = txList,
        };
    }
    
    [Name("getTokenPoolRecords")]
    public static async Task<TokenTransferListPageResultDto> GetTokenPoolRecordListAsync(
        [FromServices] IAElfIndexerClientEntityRepository<TokenTransferIndex, LogEventInfo> repository,
        [FromServices] IObjectMapper objectMapper,
        GetTokenTransferInput input
    )
    {
        var mustQuery = new List<Func<QueryContainerDescriptor<TokenTransferIndex>, QueryContainer>>();
        mustQuery.Add(q => q.Terms(i
            => i.Field(f => f.TransactionId).Terms(input.TransactionIds)));

        if (input.StartBlockHeight > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.BlockHeight).GreaterThanOrEquals(input.StartBlockHeight)));
        }

        if (input.EndBlockHeight > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.BlockHeight).LessThanOrEquals(input.EndBlockHeight)));
        }
        
        if (input.TimestampMin > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.Timestamp).GreaterThanOrEquals(input.TimestampMin)));
        }

        if (input.TimestampMax > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.Timestamp).LessThanOrEquals(input.TimestampMax)));
        }
        
        if (input.IsFilterEmpty)
        {
            mustQuery.Add(q => q.Term(i
                => i.Field(f => f.IsTransparent).Value(true)));
        }
        
        if (input.TransferType != TokenTransferType.All)
        {
            mustQuery.Add(q => q.Term(i
                => i.Field(f => f.TransferType).Value(input.TransferType.ToString())));
        }

        QueryContainer Filter(QueryContainerDescriptor<TokenTransferIndex> f) =>
            f.Bool(b => b.Must(mustQuery));

        var result = await repository.GetListAsync(Filter, skip: input.SkipCount, limit: input.MaxResultCount, 
            sortType: SortOrder.Ascending, sortExp: o => o.Timestamp);
        var txList = objectMapper.Map<List<TokenTransferIndex>, List<TokenTransferResultDto>>(result.Item2);
        return new TokenTransferListPageResultDto
        {
            TotalCount = result.Item1,
            Data = txList
        };
    }

    public static async Task<PagedResultDto<TokenSwapRecordDto>> GetSwapTokenRecord(
        [FromServices] IAElfIndexerClientEntityRepository<TokenSwapRecordIndex, LogEventInfo> tokenSwapRepository,
        [FromServices] IObjectMapper objectMapper, GetTokenSwapRecordInput input)
    {
        input.Validate();
        var mustQuery = new List<Func<QueryContainerDescriptor<TokenSwapRecordIndex>, QueryContainer>>();
        if (!input.ChainId.IsNullOrWhiteSpace())
        {
            mustQuery.Add(q => q.Term(i => i.Field(f => f.ChainId).Value(input.ChainId)));
        }
        if (input.TransactionIds != null && input.TransactionIds.Any())
        {
            mustQuery.Add(q => q.Terms(i
                => i.Field(f => f.TransactionId).Terms(input.TransactionIds)));  }

        if (!input.Channel.IsNullOrWhiteSpace())
        {
            mustQuery.Add(q => q.Term(i => i.Field(f => f.Channel).Value(input.Channel)));

        }
        if (input.StartBlockHeight.HasValue)
        {
            mustQuery.Add(q => q.Range(i => i.Field(f => f.BlockHeight).GreaterThanOrEquals(input.StartBlockHeight.Value)));
        }
        
        if (input.EndBlockHeight.HasValue)
        {
            mustQuery.Add(q => q.Range(i => i.Field(f => f.BlockHeight).LessThanOrEquals(input.EndBlockHeight.Value)));
        }
        
        if (input.TimestampMin is > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.Timestamp).GreaterThanOrEquals(input.TimestampMin)));
        }

        if (input.TimestampMax is > 0)
        {
            mustQuery.Add(q => q.Range(i
                => i.Field(f => f.Timestamp).LessThanOrEquals(input.TimestampMax)));
        }
        QueryContainer Filter(QueryContainerDescriptor<TokenSwapRecordIndex> f) => f.Bool(b => b.Must(mustQuery));
        var result = await tokenSwapRepository.GetListAsync(Filter, sortExp: k => k.BlockHeight,
            sortType: SortOrder.Ascending, limit: input.MaxResultCount.Value, skip: input.SkipCount.Value);
        var totalCount = 0L;
        var tokenSwapRecordDtos =  objectMapper.Map<List<TokenSwapRecordIndex>, List<TokenSwapRecordDto>>(result.Item2);
        if (result.Item2.Count != 0)
        {
            totalCount = (await tokenSwapRepository.CountAsync(Filter)).Count;
        }
        return new PagedResultDto<TokenSwapRecordDto>(totalCount, tokenSwapRecordDtos);
    }
}