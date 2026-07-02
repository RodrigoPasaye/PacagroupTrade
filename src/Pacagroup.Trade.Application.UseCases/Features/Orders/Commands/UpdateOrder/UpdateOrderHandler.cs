using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Application.Interfaces.Persistence;

namespace Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
            if (order is not null)
            {
                order.Quanty = request.Quanty;
                order.Type = (Domain.Enums.OrderType)request.Type;
                order.Price = request.Price;
                order.Text = request.Text;
            }

            if (await _context.SaveChangesAsync(cancellationToken) > 0)
                return true;
            else
                return false;
        }
    }
}
