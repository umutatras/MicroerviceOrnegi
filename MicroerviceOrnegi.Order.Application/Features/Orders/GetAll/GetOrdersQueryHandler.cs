using AutoMapper;
using MediatR;
using MicroerviceOrnegi.Order.Application.Conracts.Repositories;
using MicroerviceOrnegi.Order.Application.Features.Orders.Create;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.GetAll
{
    public class GetOrdersQueryHandler(IIdentityService identityService, IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrdersResponse>>>
    {
        public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetOrderByBuyerId(identityService.UserId);


            var response = orders.Select(x => new GetOrdersResponse(x.Created, x.TotalPrice, mapper.Map<List<OrderItemDto>>(x.OrderItems))).ToList();

            return ServiceResult<List<GetOrdersResponse>>.SuccessAsOk(response);
        }
    }
}
