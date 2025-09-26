using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.Create
{
    public record CreatePaymentCommand(string OrderCode, string CardNumber, string CardHolderName, string CardExpirationDate, string CardSecurityNumber, decimal Amount) : IRequestByServiceResult;
}
