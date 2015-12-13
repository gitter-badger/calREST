using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace calREST.DAL.GenericRepository
{
    /// <summary>
    /// Entity Framework interface implementation for IRepository.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TId">Type of entity Id</typeparam>
    public interface IEntityRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : IComparable
    {

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetSingleIncluding(TId id, params Expression<Func<TEntity, object>>[] includeProperties);

        PaginatedList<TEntity> Paginate<TKey>(
            int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector);

        PaginatedList<TEntity> Paginate<TKey>(
            int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        PaginatedList<TEntity> PaginateDescending<TKey>(
            int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector);

        PaginatedList<TEntity> PaginateDescending<TKey>(
            int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Exists(TId entity);
    }
}
