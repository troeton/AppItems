using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
               Expression<Func<TEntity, bool>>? filter = null,
               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
               string includeProperties = "");
        Task InsertAsync(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
