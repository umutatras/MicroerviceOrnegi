using MediatR;
using MicroerviceOrnegi.Shared.Extensions;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.GetBasket
{


    public static class GetBasketQueryEndpoint
    {
        public static RouteGroupBuilder GetBasketQueryItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/user", async (IMediator mediator) => (await mediator.Send(new GetBasketQuery())).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
