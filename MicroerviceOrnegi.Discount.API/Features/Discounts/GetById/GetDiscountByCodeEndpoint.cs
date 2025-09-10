using MediatR;
using MicroerviceOrnegi.Shared.Filter;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.GetById
{
    public static class GetDiscountByCodeEndpoint
    {
        public static RouteGroupBuilder GetDiscountByCodeGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{code}", async (string code,IMediator mediator) => (await mediator.Send(new GetDiscountByCodeQuery(code))).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
