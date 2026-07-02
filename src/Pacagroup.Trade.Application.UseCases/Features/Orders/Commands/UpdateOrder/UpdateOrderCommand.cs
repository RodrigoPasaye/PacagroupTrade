using MediatR;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.UpdateOrder
{
    public sealed record UpdateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int Quanty { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }
        public string? Text { get; set; }
    }

    public enum OrderType
    {
        LIMIT = 0,
        MARKET = 1,
    }
}
