using MediatR;
using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Basket.API.Dtos;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Create
{
    public class AddBasketItemCommandHandler(IDistributedCache cache, IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {

            var cacheKey = string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);

            var basketAsString = await cache.GetStringAsync(cacheKey, cancellationToken);

            BasketDto? currentBasket;
            BasketItemDto newBasketItem = new BasketItemDto(request.CourseId,
           request.CourseName,
           request.ImageUrl,
            request.CoursePrice,
           null);

            if (string.IsNullOrEmpty(basketAsString))
            {
                currentBasket = new BasketDto(identityService.GetUserId, [newBasketItem]);
                await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

                return ServiceResult.SuccessAsNoContent();
            }

            currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);
            var existBasketItem = currentBasket?.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);
            if (existBasketItem is not null)
            {
                currentBasket.BasketItems.Remove(existBasketItem);
            }
            currentBasket.BasketItems.Add(newBasketItem);

            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();



        }
        private async Task CreateCacheAsync(BasketDto basket,string cacheKey,CancellationToken token)
        {
            var basketAsString = JsonSerializer.Serialize(basket);

            await cache.SetStringAsync(cacheKey, basketAsString, token);
        }
    }
 
}
