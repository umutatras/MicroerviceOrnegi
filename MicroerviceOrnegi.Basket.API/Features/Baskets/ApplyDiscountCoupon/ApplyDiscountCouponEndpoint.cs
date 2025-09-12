using MediatR;
using MicroerviceOrnegi.Shared.Extensions;
using MicroerviceOrnegi.Shared.Filter;
namespace MicroerviceOrnegi.Basket.API.Features.Baskets.ApplyDiscountCoupon
{

    public static class ApplyDiscountCouponEndpoint
    {
        public static RouteGroupBuilder ApplyDiscountCouponItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/apply-discount-rate", async (ApplyDiscountCouponCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommand>>(); ;

            return group;
        }
    }
}
