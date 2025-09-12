using MediatR;
using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Basket.API.Features.Baskets.Data;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Create
{
    public class AddBasketItemCommandHandler(IDistributedCache cache, IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {

            var cacheKey = string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);

            var basketAsString = await cache.GetStringAsync(cacheKey, cancellationToken);

            Data.Basket? currentBasket;
            BasketItem newBasketItem = new BasketItem(request.CourseId,
           request.CourseName,
           request.ImageUrl,
            request.CoursePrice,
           null);

            if (string.IsNullOrEmpty(basketAsString))
            {
                currentBasket = new Data.Basket(identityService.GetUserId, [newBasketItem]);
                await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

                return ServiceResult.SuccessAsNoContent();
            }

            currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);
            var existBasketItem = currentBasket?.Items.FirstOrDefault(x => x.Id == request.CourseId);
            if (existBasketItem is not null)
            {
                currentBasket.Items.Remove(existBasketItem);
            }
            currentBasket.Items.Add(newBasketItem);

            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();



        }
        private async Task CreateCacheAsync(Data.Basket basket, string cacheKey, CancellationToken token)
        {
            var basketAsString = JsonSerializer.Serialize(basket);

            await cache.SetStringAsync(cacheKey, basketAsString, token);
        }
    }

}
