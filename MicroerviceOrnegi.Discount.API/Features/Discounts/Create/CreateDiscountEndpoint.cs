using MediatR;
using MicroerviceOrnegi.Shared.Filter;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.Create
{
    public static class CreateDiscountEndpoint
    {
        public static RouteGroupBuilder CreateDiscountGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateDiscountCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<CreateDiscountCommand>>();

            return group;
        }
    }
}
