using Asp.Versioning.Builder;
using MicroerviceOrnegi.Basket.API.Features.Baskets.ApplyDiscountCoupon;
using MicroerviceOrnegi.Basket.API.Features.Baskets.Create;
using MicroerviceOrnegi.Basket.API.Features.Baskets.Delete;
using MicroerviceOrnegi.Basket.API.Features.Baskets.GetBasket;
using MicroerviceOrnegi.Basket.API.Features.Baskets.RemoveDiscount;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets
{

    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets/item")
                .WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketQueryItemGroupItemEndpoint()
                .ApplyDiscountCouponItemGroupItemEndpoint()
                .RemoveDiscountCouponGroupItemEndpoint();
        }
    }
}
