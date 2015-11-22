using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data.Framework.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task AddAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(string id);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, int limit, int offset);

        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, int limit, int offset,
            Expression<Func<TEntity, object>> sortKeySelector, bool ascending = true);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        Task<long> CountAsync();
    }
}
