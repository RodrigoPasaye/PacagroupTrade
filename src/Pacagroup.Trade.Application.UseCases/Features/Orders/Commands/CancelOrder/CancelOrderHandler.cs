using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public CancelOrderHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(request.Id) , cancellationToken);

            if (order is not null)
                _context.Orders.Remove(order);

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
                return true;
            else
                return false;
        }
    }
}
