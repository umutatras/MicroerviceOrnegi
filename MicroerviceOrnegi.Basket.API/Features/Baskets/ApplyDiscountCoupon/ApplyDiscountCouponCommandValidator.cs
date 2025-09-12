using FluentValidation;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponCommandValidator : AbstractValidator<ApplyDiscountCouponCommand>
    {
        public ApplyDiscountCouponCommandValidator()
        {
            RuleFor(x => x.Coupon).NotEmpty().WithMessage("Coupon code must be provided.");
        }
    }
}
