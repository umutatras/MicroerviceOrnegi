using MediatR;
using MicroerviceOrnegi.Order.Application.Features.Orders.GetAll;
using MicroerviceOrnegi.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MicroerviceOrnegi.Order.API.Endpoints.Orders
{
    public static class GetOrdersEndpoint
    {
        public static RouteGroupBuilder GetOrdersGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] IMediator mediator) => (await mediator.Send(new GetOrdersQuery())).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
