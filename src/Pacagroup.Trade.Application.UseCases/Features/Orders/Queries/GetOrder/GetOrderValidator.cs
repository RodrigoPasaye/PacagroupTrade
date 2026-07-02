using FluentValidation;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder
{
    public class GetOrderValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
