using AutoMapper;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.UseCases.Commons.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
            CreateMap<GetOrderResponseDTO, Order>().ReverseMap();
            CreateMap<GetAllOrderResponseDTO, Order>().ReverseMap();
        }
    }
}
