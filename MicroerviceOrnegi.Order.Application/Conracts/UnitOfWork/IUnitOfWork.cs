namespace MicroerviceOrnegi.Order.Application.Conracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken token = default);
        Task BeginTransactionAsync(CancellationToken token = default);
        Task CommitTransactionAsync(CancellationToken token = default);
    }
}
