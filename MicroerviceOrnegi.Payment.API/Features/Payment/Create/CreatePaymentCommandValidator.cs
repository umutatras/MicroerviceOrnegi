using FluentValidation;

namespace MicroerviceOrnegi.Payment.API.Features.Payment.Create
{
    public class CreatePaymentCommandValidator:AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.OrderCode).NotEmpty().WithMessage("Order code is required");
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Card number is required").CreditCard().WithMessage("Invalid card number");
            RuleFor(x => x.CardHolderName).NotEmpty().WithMessage("Card holder name is required");
         
        }
    }
}
