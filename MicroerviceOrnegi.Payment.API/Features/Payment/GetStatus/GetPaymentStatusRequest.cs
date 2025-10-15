using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.GetStatus
{
    public record GetPaymentStatusRequest(string orderCode) : IRequestByServiceResult<GetPaymentStatusResponse>;
}
