using Asp.Versioning.Builder;
using MicroerviceOrnegi.Basket.API.Features.Baskets.Create;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets
{
  
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets/item")
                .WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint();
        }
    }
}
