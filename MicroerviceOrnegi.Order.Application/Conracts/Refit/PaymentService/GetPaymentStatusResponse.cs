namespace MicroerviceOrnegi.Order.Application.Conracts.Refit.PaymentService
{
    public record GetPaymentStatusResponse(Guid? PaymentId, bool IsPaid);
}
