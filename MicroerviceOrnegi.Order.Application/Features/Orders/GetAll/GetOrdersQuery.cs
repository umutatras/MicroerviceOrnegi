using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.GetAll
{
    public record GetOrdersQuery:IRequestByServiceResult<List<GetOrdersResponse>>;
   
