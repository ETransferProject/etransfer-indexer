using System.Linq.Expressions;
using AeFinder.Sdk;
using ETransferIndexer.Entities;
using GraphQL;
using Volo.Abp.ObjectMapping;
using ETransferIndexer.GraphQL.Dto;
using ETransferIndexer.GraphQL.Input;

namespace ETransferIndexer.GraphQL;

public class Query
{
    [Name("getLatestBlock")]
    public static async Task<LatestBlockDto> GetLatestBlockAsync(
        [FromServices] IReadOnlyRepository<LatestBlockIndex> repository,
        [FromServices] IObjectMapper objectMapper,
        GetLatestBlockInput input
    )
    {
        var queryable = await repository.GetQueryableAsync();
        queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);

        var latestBlock = queryable.FirstOrDefault();
        if (latestBlock == null) return null;

        return objectMapper.Map<LatestBlockIndex, LatestBlockDto>(latestBlock);
    }

    [Name("getTransaction")]
    public static async Task<TransactionListPageResultDto> GetTransactionListAsync(
        [FromServices] IReadOnlyRepository<ETransferTransactionIndex> repository,
        [FromServices] IObjectMapper objectMapper,
        GetTransactionListInput input
    )
    {
        var queryable = await repository.GetQueryableAsync();
        if (!input.TransactionIds.IsNullOrEmpty())
        {
            queryable = queryable.Where(input.TransactionIds.Select(txId =>
                    (Expression<Func<ETransferTransactionIndex, bool>>)(t => t.TransactionId == txId))
                .Aggregate((prev, next) => prev.Or(next)));
        }

        if (input.StartBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight);
        }

        if (input.EndBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight);
        }

        var result = queryable.Skip(input.SkipCount.Value).Take(input.MaxResultCount.Value).ToList();
        var txList = objectMapper.Map<List<ETransferTransactionIndex>, List<TransactionResultDto>>(result);
        return new TransactionListPageResultDto
        {
            TotalCount = queryable.Count(),
            Data = txList,
        };
    }

    [Name("getTokenPoolRecords")]
    public static async Task<TokenTransferListPageResultDto> GetTokenPoolRecordListAsync(
        [FromServices] IReadOnlyRepository<TokenTransferIndex> repository,
        [FromServices] IObjectMapper objectMapper,
        GetTokenTransferInput input
    )
    {
        var queryable = await repository.GetQueryableAsync();
        if (!input.TransactionIds.IsNullOrEmpty())
        {
            queryable = queryable.Where(input.TransactionIds.Select(txId =>
                    (Expression<Func<TokenTransferIndex, bool>>)(t => t.TransactionId == txId))
                .Aggregate((prev, next) => prev.Or(next)));
        }

        if (input.StartBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight);
        }

        if (input.EndBlockHeight > 0)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight);
        }

        if (input.TimestampMin > 0)
        {
            queryable = queryable.Where(a => a.Timestamp >= input.TimestampMin);
        }

        if (input.TimestampMax > 0)
        {
            queryable = queryable.Where(a => a.Timestamp <= input.TimestampMax);
        }

        if (input.IsFilterEmpty)
        {
            queryable = queryable.Where(a => a.IsTransparent == true);
        }

        if (input.TransferType != TokenTransferType.All)
        {
            queryable = queryable.Where(a => a.TransferType == input.TransferType.ToString());
        }

        var result = queryable.OrderBy(o => o.Timestamp)
            .Skip(input.SkipCount.Value).Take(input.MaxResultCount.Value).ToList();
        var txList = objectMapper.Map<List<TokenTransferIndex>, List<TokenTransferResultDto>>(result);
        return new TokenTransferListPageResultDto
        {
            TotalCount = queryable.Count(),
            Data = txList
        };
    }

    [Name("getSwapTokenRecord")]
    public static async Task<TokenSwapListPageResultDto> GetSwapTokenRecordAsync(
        [FromServices] IReadOnlyRepository<TokenSwapRecordIndex> tokenSwapRepository,
        [FromServices] IObjectMapper objectMapper,
        GetTokenSwapRecordInput input)
    {
        var queryable = await tokenSwapRepository.GetQueryableAsync();
        if (!input.ChainId.IsNullOrWhiteSpace())
        {
            queryable = queryable.Where(a => a.Metadata.ChainId == input.ChainId);
        }

        if (input.TransactionIds != null && input.TransactionIds.Any())
        {
            queryable = queryable.Where(input.TransactionIds.Select(txId =>
                    (Expression<Func<TokenSwapRecordIndex, bool>>)(t => t.TransactionId == txId))
                .Aggregate((prev, next) => prev.Or(next)));
        }

        if (!input.Channel.IsNullOrWhiteSpace())
        {
            queryable = queryable.Where(a => a.Channel == input.Channel);
        }

        if (input.StartBlockHeight.HasValue)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight >= input.StartBlockHeight.Value);
        }

        if (input.EndBlockHeight.HasValue)
        {
            queryable = queryable.Where(a => a.Metadata.Block.BlockHeight <= input.EndBlockHeight.Value);
        }

        if (input.TimestampMin is > 0)
        {
            queryable = queryable.Where(a => a.Timestamp >= input.TimestampMin);
        }

        if (input.TimestampMax is > 0)
        {
            queryable = queryable.Where(a => a.Timestamp <= input.TimestampMax);
        }

        var result = queryable.OrderBy(o => o.Metadata.Block.BlockHeight)
            .Skip(input.SkipCount.Value).Take(input.MaxResultCount.Value).ToList();
        var tokenSwapRecordDtos = objectMapper.Map<List<TokenSwapRecordIndex>, List<TokenSwapRecordDto>>(result);
        return new TokenSwapListPageResultDto
        {
            TotalCount = queryable.Count(),
            Data = tokenSwapRecordDtos
        };
    }
}