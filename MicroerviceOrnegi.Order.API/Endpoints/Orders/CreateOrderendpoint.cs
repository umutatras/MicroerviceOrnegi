using MediatR;
using MicroerviceOrnegi.Order.Application.Features.Orders.Create;
using MicroerviceOrnegi.Shared.Extensions;
using MicroerviceOrnegi.Shared.Filter;
using Microsoft.AspNetCore.Mvc;

namespace MicroerviceOrnegi.Order.API.Endpoints.Orders
{
    public static class CreateOrderendpoint
    {
        public static RouteGroupBuilder CreateOrderGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async ([FromBody] CreateOrderCommand Command, [FromServices] IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<CreateOrderCommand>>();

            return group;
        }
    }
}
