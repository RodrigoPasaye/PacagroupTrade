using FluentValidation;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Quanty).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
