using FluentValidation;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Symbol).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.Currency).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.Side).IsInEnum();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Quanty).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
