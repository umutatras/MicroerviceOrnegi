using MediatR;
using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandHandler(IIdentityService identityService, IDistributedCache cache) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);

            var basketAsJson = await cache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsJson))
            {
                return ServiceResult.Error("Basket Not Found", "There is no basket for this user", System.Net.HttpStatusCode.NotFound);
            }

            var basket = System.Text.Json.JsonSerializer.Deserialize<Data.Basket>(basketAsJson);
            if (!basket.Items.Any())
            {
                return ServiceResult.Error("BasketItem Not Found", "There is no basket for this user", System.Net.HttpStatusCode.NotFound);
            }
            basket.ApplyNewDiscount(request.Coupon, request.Rate);
            var basketAsUpdatedJson = System.Text.Json.JsonSerializer.Serialize(basket);

            await cache.SetStringAsync(cacheKey, basketAsUpdatedJson, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
