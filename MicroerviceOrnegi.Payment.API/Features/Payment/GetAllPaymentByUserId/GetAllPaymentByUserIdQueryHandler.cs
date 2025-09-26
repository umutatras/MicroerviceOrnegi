using MediatR;
using MicroerviceOrnegi.Payment.API.Repositories;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.GetAllPaymentByUserId
{
    public class GetAllPaymentByUserIdQueryHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<GetAllPaymentByUserIdQuery, ServiceResult<List<GetAllPaymentByUserIdResponse>>>
    {
        public async Task<ServiceResult<List<GetAllPaymentByUserIdResponse>>> Handle(GetAllPaymentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = identityService.GetUserId;
            var payments = await context.Payments.Where(p => p.UserId == userId).Select(p => new GetAllPaymentByUserIdResponse(p.Id, p.OrderCode, p.Amount.ToString("C"), p.Created, p.Status)).ToListAsync(cancellationToken);

            return ServiceResult<List<GetAllPaymentByUserIdResponse>>.SuccessAsOk(payments);
        }
    }
}
