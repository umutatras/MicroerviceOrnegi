using System.Linq.Expressions;

namespace MicroerviceOrnegi.Order.Application.Conracts
{
    public interface IGenericRepository<TId, TEntity> where TEntity : class
        where TId : struct
    {
        public Task<bool> AnyAsync(TId id);
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllPagedAsync(int pageNumber, int pageSize);
        ValueTask<TEntity> GetByIdAsync(TId id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        void AddAsync(TEntity entity);

        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
