using MediatR;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder
{
    public sealed record GetOrderQuery : IRequest<GetOrderResponseDTO>
    {
        public int Id { get; set; }
    }
}
