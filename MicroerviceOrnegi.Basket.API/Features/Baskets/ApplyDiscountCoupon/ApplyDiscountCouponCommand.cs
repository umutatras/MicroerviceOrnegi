using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public record ApplyDiscountCouponCommand(string Coupon,float Rate):IRequestByServiceResult
    {
    }
}
