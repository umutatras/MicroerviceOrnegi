using FluentValidation;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Delete
{
    public class DeleteBasketItemCommandValidator:AbstractValidator<DeleteBasketItemCommand>
    {
        public DeleteBasketItemCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty().WithMessage("CourseId is required");
        }
    }
}
