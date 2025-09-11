using MediatR;
using MicroerviceOrnegi.Basket.API.Features.Baskets.Create;
using MicroerviceOrnegi.Shared.Filter;
using MicroerviceOrnegi.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Delete
{
    public static class DeleteBasketEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}", async (IMediator mediator,Guid id) => (await mediator.Send(new DeleteBasketItemCommand(id))).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<DeleteBasketItemCommand>>();

            return group;
        }
    }
 
}
