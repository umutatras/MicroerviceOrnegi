namespace MicroerviceOrnegi.Payment.API.Features.Payment.GetStatus
{
    public record GetPaymentStatusResponse(Guid? PaymentId, bool IsPaid);
}
