using MassTransit;
using MediatR;
using MicroerviceOrnegi.Discount.API.Repositories;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.Create
{
    public class CreateDiscountCommandHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<CreateDiscountCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var hasCode = await context.Discounts.AnyAsync(x => x.Code == request.Code && x.UserId == identityService.UserId, cancellationToken);
            if (hasCode)
            {
                return ServiceResult.Error("This code already exists.", "", System.Net.HttpStatusCode.BadRequest);
            }
            var discount = new Discount
            {
                Id = NewId.NextSequentialGuid(),
                Code = request.Code,
                Created = DateTime.Now,
                Expired = request.Expired,
                Rate = request.Rate,
                UserId = request.UserId,
            };
            await context.Discounts.AddAsync(discount, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }
    }
}
