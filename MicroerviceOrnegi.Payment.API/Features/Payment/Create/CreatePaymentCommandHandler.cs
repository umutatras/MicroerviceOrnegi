using MediatR;
using MicroerviceOrnegi.Payment.API.Repositories;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.Create
{
    public class CreatePaymentCommandHandler(AppDbContext appDbContext, IIdentityService identityService) : IRequestHandler<CreatePaymentCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var (isSuccess, errorMessage) = await ExternalPaymentProcessAsync(request.CardNumber, request.CardHolderName, request.CardExpirationDate, request.CardSecurityNumber, request.Amount);

            if (!isSuccess)
            {
                return ServiceResult.Error("Payment Failed", errorMessage ?? "Payment process failed", System.Net.HttpStatusCode.BadRequest);
            }

            var newPayment = new Repositories.Payment(identityService.GetUserId, request.OrderCode, request.Amount);
            newPayment.SetStatus(PaymentStatus.Success);
            await appDbContext.Payments.AddAsync(newPayment, cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);
            return ServiceResult.SuccessAsNoContent();

        }

        private async Task<(bool isSuccess, string? errorMessage)> ExternalPaymentProcessAsync(string cardNumber, string cardHolderName, string cardExpirationDate, string cardSecurityNumber, decimal amount)
        {
            await Task.Delay(2000);
            return (true, null);
        }
    }
}
