using MediatR;
using MicroerviceOrnegi.Basket.API.Const;
using MicroerviceOrnegi.Basket.API.Features.Baskets.Create;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Filter;
using MicroerviceOrnegi.Shared.Services;
using MicroerviceOrnegi.Shared.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.RemoveDiscount
{

    public record RemoveDiscountCouponCommand:IRequestByServiceResult;


    public class RemoveDiscountCouponHandler(IIdentityService service,IDistributedCache cache) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = string.Format(BasketConst.BasketCacheKey, service.GetUserId);

            var basketAsString = await cache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult.Error("Basket Not Found", "Basket not found for the user", System.Net.HttpStatusCode.NotFound);
            }   

            var basket=JsonSerializer.Deserialize<Data.Basket>(basketAsString);

            basket!.ClearDiscount();

            basketAsString = JsonSerializer.Serialize(basket);
            await cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(basket), cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }
    }
    public static class RemoveDiscountCouponEndpoint
    {
        public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (RemoveDiscountCouponCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }


}
