﻿using MassTransit;
using MediatR;
using MicroerviceOrnegi.Bus.Events;
using MicroerviceOrnegi.Order.Application.Conracts.Refit.PaymentService;
using MicroerviceOrnegi.Order.Application.Conracts.Repositories;
using MicroerviceOrnegi.Order.Application.Conracts.UnitOfWork;
using MicroerviceOrnegi.Order.Domain.Entities;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Services;
using System.Net;

namespace MicroerviceOrnegi.Order.Application.Features.Orders.Create;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IGenericRepository<int, Address> addressRepository,
    IIdentityService identityService,
    IUnitOfWork unitOfWork,
    IPublishEndpoint publishEndpoint,
    IPaymentService paymentService) : IRequestHandler<CreateOrderCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (!request.Items.Any())
            return ServiceResult.Error("Order items not found", "Order must have at least one item",
                HttpStatusCode.BadRequest);


        var newAddress = new Address
        {
            Province = request.Address.Province,
            District = request.Address.District,
            Street = request.Address.Street,
            ZipCode = request.Address.ZipCode,
            Line = request.Address.Line
        };


        var order = Domain.Entities.Order.CreateUnPaidOrder(identityService.UserId, request.DiscountRate,
            newAddress.Id);
        foreach (var orderItem in request.Items)
            order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice);


        order.Address = newAddress;


        orderRepository.AddAsync(order);
        await unitOfWork.CommitAsync(cancellationToken);


        var paymentRequest = new CreatePaymentRequest(order.Code, request.Payment.CardNumber,
            request.Payment.CardHolderName, request.Payment.Expiration, request.Payment.Cvc, order.TotalPrice);
        var paymentResponse = await paymentService.CreateAsync(paymentRequest);


        if (!paymentResponse.Status)
            return ServiceResult.Error(paymentResponse.ErrorMessage!, HttpStatusCode.InternalServerError);


        order.SetPaidStatus(paymentResponse.PaymentId!.Value);

        orderRepository.Update(order);
        await unitOfWork.CommitAsync(cancellationToken);


        await publishEndpoint.Publish(new OrderCreatedEvent(order.Id, identityService.UserId),
            cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }
}