using FluentValidation;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Address).NotNull().WithMessage("Address is required").SetValidator(new AddressValidator());
            RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
        }
    }
    public class OrderItemValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName is required");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("UnitPrice must be greater than zero");
        }
    }
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Province).NotEmpty().WithMessage("Province is required");
            RuleFor(x => x.District).NotEmpty().WithMessage("District is required");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("ZipCode is required");
            RuleFor(x => x.Line).NotEmpty().WithMessage("Line is required");
        }
    }
}
