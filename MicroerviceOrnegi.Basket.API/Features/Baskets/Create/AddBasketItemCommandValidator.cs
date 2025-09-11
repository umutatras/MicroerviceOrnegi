using FluentValidation;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Create
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty();
            RuleFor(x => x.CourseName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CoursePrice).GreaterThan(-1);
        }
    }
}
