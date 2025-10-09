using MassTransit;
using MediatR;
using MicroerviceOrnegi.Bus.Events;
using MicroerviceOrnegi.Order.Application.Conracts.Repositories;
using MicroerviceOrnegi.Order.Application.Conracts.UnitOfWork;
using MicroerviceOrnegi.Order.Domain.Entities;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.Create
{
    public class CreateOrderCommandHandler(IOrderRepository orderRepository, IIdentityService identityService, IUnitOfWork unitOfWork,IPublishEndpoint publishEndpoint) : IRequestHandler<CreateOrderCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            if (!request.Items.Any())
            {
                return ServiceResult.Error("Order items not found", "", System.Net.HttpStatusCode.NotFound);
            }
            var newAddress = new Address
            {
                District = request.Address.District,
                Line = request.Address.Line,
                Province = request.Address.Province,
                Street = request.Address.Street
                ,
                ZipCode = request.Address.ZipCode,
            };

            var order = Domain.Entities.Order.CreateUnPaidOrder(identityService.UserId, request.DiscountRate, newAddress.Id);

            foreach (var item in request.Items)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice);
            }
            order.Address = newAddress;
            orderRepository.AddAsync(order);
            await unitOfWork.CommitAsync(cancellationToken);
            var paymentId = Guid.Empty;

            order.SetPaidStatus(paymentId);

            orderRepository.Update(order);
            await unitOfWork.CommitAsync(cancellationToken);
            await publishEndpoint.Publish(new OrderCreatedEvent(order.Id, identityService.UserId));
            return ServiceResult.SuccessAsNoContent();
        }
    }
}
