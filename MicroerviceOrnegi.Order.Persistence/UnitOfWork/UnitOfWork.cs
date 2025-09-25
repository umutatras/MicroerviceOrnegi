using MicroerviceOrnegi.Order.Application.Conracts.UnitOfWork;

namespace MicroerviceOrnegi.Order.Persistence.UnitOfWork
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task BeginTransactionAsync(CancellationToken token = default)
        {
            await context.Database.BeginTransactionAsync(token);
        }

        public Task CommitTransactionAsync(CancellationToken token = default)
        {
            return context.Database.CommitTransactionAsync(token);
        }

        public Task<int> CommitAsync(CancellationToken token = default)
        {
            return context.SaveChangesAsync(token);
        }
    }
}
