using MediatR;
using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Basket.API.Dtos;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.GetBasket
{
    public class GetBasketQueryHandler(IDistributedCache cache,IIdentityService service) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = string.Format(BasketConst.BasketCacheKey, service.GetUserId);

            var basketAsString = await cache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);
            }
            var basket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

            return ServiceResult<BasketDto>.SuccessAsOk(basket);
        }
    }
}
