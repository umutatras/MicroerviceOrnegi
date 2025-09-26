using MicroerviceOrnegi.Order.Application.Features.Orders.Create;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.GetAll
{
    public record GetOrdersResponse(DateTime Created, decimal TotalPrice, List<OrderItemDto> Items);

}
