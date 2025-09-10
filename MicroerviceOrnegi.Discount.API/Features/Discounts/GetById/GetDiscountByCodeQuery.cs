using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.GetById
{
    public record GetDiscountByCodeQuery(string Code) : IRequestByServiceResult<GetDiscountByCodeQueryResponse>;

}
