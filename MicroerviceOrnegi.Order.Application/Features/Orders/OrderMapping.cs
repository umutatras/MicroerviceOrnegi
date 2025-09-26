using AutoMapper;
using MicroerviceOrnegi.Order.Application.Features.Orders.Create;
using MicroerviceOrnegi.Order.Application.Features.Orders.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroerviceOrnegi.Order.Application.Features.Orders
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Domain.Entities.Order, OrderItemDto>().ReverseMap();
        }
    }
}
