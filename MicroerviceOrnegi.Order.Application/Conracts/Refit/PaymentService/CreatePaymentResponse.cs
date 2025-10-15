namespace MicroerviceOrnegi.Order.Application.Conracts.Refit.PaymentService
{
    public record CreatePaymentResponse(Guid? PaymentId, bool Status, string? ErrorMessage);
}
