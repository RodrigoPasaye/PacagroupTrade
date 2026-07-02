using AutoMapper;
using MediatR;
using Pacagroup.Trade.Application.Interfaces.Persistence;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _context.Orders.AddAsync(order, cancellationToken);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
                return true;
            else
                return false;
        }
    }
}
