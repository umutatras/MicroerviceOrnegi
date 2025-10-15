namespace MicroerviceOrnegi.Order.Application.Conracts.Refit.PaymentService
{
    public record CreatePaymentRequest(
    string OrderCode,
    string CardNumber,
    string CardHolderName,
    string CardExpirationDate,
    string CardSecurityNumber,
    decimal Amount);
}
