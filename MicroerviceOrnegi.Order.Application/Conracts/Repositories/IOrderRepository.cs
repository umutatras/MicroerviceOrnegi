﻿using MicroerviceOrnegi.Order.Domain.Entities;

namespace MicroerviceOrnegi.Order.Application.Conracts.Repositories
{
    public interface IOrderRepository : IGenericRepository<Guid, Domain.Entities.Order>
    {
        Task<List<Domain.Entities.Order>> GetOrderByBuyerId(Guid buyerId);
        Task SetStatus(string orderCode, Guid paymentId, OrderStatus status);

    }
}
