using Asp.Versioning.Builder;
using MicroerviceOrnegi.Payment.API.Features.Payment.Create;
using MicroerviceOrnegi.Payment.API.Features.Payment.GetAllPaymentByUserId;

namespace MicroerviceOrnegi.Payment.API.Features.Payment
{

    public static class PaymentEndpointExt
    {
        public static void PaymentGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/payments")
                .WithTags("Payments")
                .WithApiVersionSet(apiVersionSet)
                .PaymentCreateGroupItemEndpoint()
                .GetAllPaymentByUserIdGroupItemEndpoint()
                .RequireAuthorization()
                ;

        }
    }
}
