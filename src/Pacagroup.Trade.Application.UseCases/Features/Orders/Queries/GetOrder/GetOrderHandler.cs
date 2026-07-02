using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderResponseDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOrderResponseDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
            var response = _mapper.Map<GetOrderResponseDTO>(order);
            return response;
        }
    }
}
