using MediatR;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder
{
    public sealed record GetAllOrderQuery : IRequest<IEnumerable<GetAllOrderResponseDTO>>
    {
    }
}
