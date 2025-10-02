using MediatR;
using MicroerviceOrnegi.Shared.Extensions;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.GetAllPaymentByUserId
{
    public static class GetAllPaymentByUserIdEndpoint
    {
        public static RouteGroupBuilder GetAllPaymentByUserIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllPaymentByUserIdQuery())).ToGenericResult()).MapToApiVersion(1, 0).RequireAuthorization("ClientCredential");

            return group;
        }
    }

}
