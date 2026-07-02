using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.CreateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Commands.UpdateOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetAllOrder;
using Pacagroup.Trade.Application.UseCases.Features.Orders.Queries.GetOrder;
using Pacagroup.Trade.Services.gRPC.Protos;

namespace Pacagroup.Trade.Services.gRPC.Commons.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderCommand, CreateOrderRequest>().ReverseMap();
            CreateMap<UpdateOrderCommand, UpdateOrderRequest>().ReverseMap();
            CreateMap<OrderResponse, GetOrderResponseDTO>().ReverseMap();
            CreateMap<OrderResponse, GetAllOrderResponseDTO>().ReverseMap();
            CreateMap<DateTime, Timestamp>()
                .ConvertUsing(x => Timestamp.FromDateTime(DateTime.SpecifyKind(x, DateTimeKind.Utc)));
            CreateMap<Timestamp, DateTime>().ConvertUsing(x => x.ToDateTime());
        }
    }
}
