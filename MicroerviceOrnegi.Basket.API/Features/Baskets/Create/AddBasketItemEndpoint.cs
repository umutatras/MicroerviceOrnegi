using MediatR;
using MicroerviceOrnegi.Shared.Filter;
using MicroerviceOrnegi.Shared.Extensions;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Create
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (AddBasketItemCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<AddBasketItemCommand>>();

            return group;
        }
    }
   
}
