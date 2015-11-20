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
        Task Add(TEntity entity);
  
        Task Update(TEntity entity);

        Task Delete(string id);
  
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    
        Task<List<TEntity>> GetAll();
  
        Task<TEntity> GetById(string id);

        Task<long> Count();
    }
}
