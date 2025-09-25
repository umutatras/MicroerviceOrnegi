namespace MicroerviceOrnegi.Order.Application.Conracts.Repositories
{
    public interface IOrderRepository : IGenericRepository<Guid, Domain.Entities.Order>
    {
    }
}
