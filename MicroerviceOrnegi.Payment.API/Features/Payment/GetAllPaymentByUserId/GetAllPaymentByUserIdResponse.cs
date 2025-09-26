using MicroerviceOrnegi.Payment.API.Repositories;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.GetAllPaymentByUserId
{
    public record GetAllPaymentByUserIdResponse(Guid Id, string OrderCode, string Amount, DateTime Created, PaymentStatus Status);
}
