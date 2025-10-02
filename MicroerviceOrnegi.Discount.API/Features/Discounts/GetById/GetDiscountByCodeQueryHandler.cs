using MediatR;
using MicroerviceOrnegi.Discount.API.Repositories;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.GetById
{
    public class GetDiscountByCodeQueryHandler(AppDbContext context, IIdentityService service) : IRequestHandler<GetDiscountByCodeQuery, ServiceResult<GetDiscountByCodeQueryResponse>>
    {
        public async Task<ServiceResult<GetDiscountByCodeQueryResponse>> Handle(GetDiscountByCodeQuery request, CancellationToken cancellationToken)
        {
            var hasDicount = await context.Discounts.FirstOrDefaultAsync(x => x.Code == request.Code && x.UserId == service.UserId, cancellationToken);
            if (hasDicount == null)
            {
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount not found", "", System.Net.HttpStatusCode.NotFound);
            }
            if (hasDicount.Expired < DateTime.Now)
            {
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount expired", "", System.Net.HttpStatusCode.BadRequest);
            }
            return ServiceResult<GetDiscountByCodeQueryResponse>.SuccessAsOk(new GetDiscountByCodeQueryResponse(hasDicount.Code,
                 hasDicount.Rate));
        }
    }
}
