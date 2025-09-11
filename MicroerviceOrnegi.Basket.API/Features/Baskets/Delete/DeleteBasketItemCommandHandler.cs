using MediatR;
using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Delete
{
    public class DeleteBasketItemCommandHandler(IDistributedCache cache,IIdentityService service) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = string.Format(BasketConst.BasketCacheKey, service.GetUserId);

            var basketAsString = await cache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult.Error("Basket not found",System.Net.HttpStatusCode.NotFound);
            }

            var currentBasket = System.Text.Json.JsonSerializer.Deserialize<Dtos.BasketDto>(basketAsString);
            var existBasketItem = currentBasket?.BasketItems.FirstOrDefault(x => x.Id == request.Id);
            if (existBasketItem is null)
            {
                return ServiceResult.Error("Basket item not found", System.Net.HttpStatusCode.NotFound);
            }
            currentBasket.BasketItems.Remove(existBasketItem);
            await cache.SetStringAsync(cacheKey, System.Text.Json.JsonSerializer.Serialize(currentBasket), cancellationToken);
            return ServiceResult.SuccessAsNoContent();

        }
    }
}
