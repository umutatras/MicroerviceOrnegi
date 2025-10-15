namespace MicroerviceOrnegi.Payment.API.Features.Payment.Create
{
    public record CreatePaymentResponse(Guid? PaymentId, bool Status, string? ErrorMessage);
}
