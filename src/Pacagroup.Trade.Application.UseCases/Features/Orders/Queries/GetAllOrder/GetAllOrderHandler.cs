using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<GetAllOrderResponseDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOrderHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllOrderResponseDTO>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<GetAllOrderResponseDTO>>(orders);
        }
    }
}
