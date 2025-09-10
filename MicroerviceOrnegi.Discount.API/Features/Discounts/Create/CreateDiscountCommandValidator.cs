using FluentValidation;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.Create
{
    public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(x => x.Rate).NotEmpty().WithMessage("hata.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        }
    }
}
