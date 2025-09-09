using FluentValidation;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandValidator:AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        }
    }
}
