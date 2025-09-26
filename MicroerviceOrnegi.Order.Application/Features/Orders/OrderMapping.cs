using AutoMapper;
using MicroerviceOrnegi.Order.Application.Features.Orders.Create;

namespace MicroerviceOrnegi.Order.Application.Features.Orders
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Domain.Entities.Order, OrderItemDto>().ReverseMap();
        }
    }
}
