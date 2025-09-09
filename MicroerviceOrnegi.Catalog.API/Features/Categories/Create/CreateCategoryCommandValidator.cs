namespace MicroerviceOrnegi.Catalog.API.Features.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Category name is required")
                .MaximumLength(100).WithMessage("Category name must be less than 100 characters");
            RuleFor(x => x.name).MinimumLength(2).WithMessage("Category name must be at least 2 characters");

        }
    }
}
