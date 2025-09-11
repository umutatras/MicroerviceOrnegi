using MediatR;
using MicroerviceOrnegi.Shared.Extensions;
using MicroerviceOrnegi.Shared.Filter;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Delete
{
    public static class DeleteBasketEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new DeleteBasketItemCommand(id))).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<DeleteBasketItemCommand>>();

            return group;
        }
    }

}
