using MediatR;
using MicroerviceOrnegi.Order.Application.Conracts.Repositories;
using MicroerviceOrnegi.Order.Domain.Entities;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.AspNetCore.Http;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.Create
{
    public class CreateOrderCommandHandler(IGenericRepository<Guid,Domain.Entities.Order> orderRepository,IGenericRepository<int,Address> addressRepository,IIdentityService identityService) : IRequestHandler<CreateOrderCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            if (!request.Items.Any())
            {
                return ServiceResult.Error("Order items not found", "", System.Net.HttpStatusCode.NotFound);
            }

            var newAddress = new Address
            {
                District=request.Address.District,
                Line=request.Address.Line,
                Province=request.Address.Province,
                Street = request.Address.Street
                ,ZipCode=request.Address.ZipCode,
            };
            addressRepository.AddAsync(newAddress);

            var order = Domain.Entities.Order.CreateUnPaidOrder(identityService.GetUserId, request.DiscountRate, newAddress.Id);

            foreach (var item in request.Items)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice);
            }

            orderRepository.AddAsync(order);

            var paymentId = Guid.Empty;

            order.SetPaidStatus(paymentId);

            orderRepository.Update(order);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
