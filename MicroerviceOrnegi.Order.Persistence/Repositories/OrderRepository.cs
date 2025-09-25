using MicroerviceOrnegi.Order.Application.Conracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MicroerviceOrnegi.Order.Persistence.Repositories;

public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Domain.Entities.Order>(context), IOrderRepository
{       

    public Task<List<Domain.Entities.Order>> GetOrderByBuyerId(Guid buyerId)
    {
        return context.Orders.Include(x=>x.OrderItems)
            .Include(x=>x.Address)
            .Where(x => x.BuyerId == buyerId)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

}
