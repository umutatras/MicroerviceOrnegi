using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MicroerviceOrnegi.Basket.API.Features;

public class BasketService(IIdentityService identityService, IDistributedCache distributedCache)
{
    private string GetCacheKey()
    {
        return string.Format(BasketConst.BasketCacheKey, identityService.UserId);
    }

    private string GetCacheKey(Guid userId)
    {
        return string.Format(BasketConst.BasketCacheKey, userId);
    }

    public Task<string?> GetBasketFromCache(CancellationToken cancellationToken)
    {
        return distributedCache.GetStringAsync(GetCacheKey(), cancellationToken);
    }

    public async Task CreateBasketCacheAsync(Baskets.Data.Basket basket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);
        await distributedCache.SetStringAsync(GetCacheKey(), basketAsString, cancellationToken);
    }

    public async Task DeleteBasket(Guid userId)
    {
        await distributedCache.RemoveAsync(GetCacheKey(userId));
    }
}