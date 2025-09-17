﻿namespace MicroerviceOrnegi.Order.Application.Features.Orders.Create
{
    public record CreateOrderCommand(float? DiscountRate, AddressDto Address, PaymentDto Payment, List<OrderItemDto> Items);
    public record AddressDto(string Province, string District, string Street, string ZipCode, string Line);
    public record PaymentDto(string CardNumber, string CardHolderName, string Expiration, string Cvc, decimal Amount);
    public record OrderItemDto(Guid ProductId, string ProductName, decimal UnitPrice);
}
