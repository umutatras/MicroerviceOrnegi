using MicroerviceOrnegi.Order.Application.Conracts.Repositories;

namespace MicroerviceOrnegi.Order.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Guid, Domain.Entities.Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
