using MediatR;
using MicroerviceOrnegi.Shared.Extensions;
using MicroerviceOrnegi.Shared.Filter;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.Create
{
   
    public static class PaymentCreateEndpoint
    {
        public static RouteGroupBuilder PaymentCreateGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreatePaymentCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult()).MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<CreatePaymentCommandValidator>>();

            return group;
        }
    }
}
