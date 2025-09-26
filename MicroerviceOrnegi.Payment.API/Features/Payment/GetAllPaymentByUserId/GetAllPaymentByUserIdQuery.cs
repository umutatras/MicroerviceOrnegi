using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.GetAllPaymentByUserId
{
    public record GetAllPaymentByUserIdQuery : IRequestByServiceResult<List<GetAllPaymentByUserIdResponse>>;

}
