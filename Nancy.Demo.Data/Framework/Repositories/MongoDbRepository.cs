using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data.Framework.Repositories
{
    public abstract class MongoDbRepository<TEntity> : IRepository<TEntity> where TEntity : MongoDbEntity
    {
        private IMongoCollection<TEntity> _collection;

        public MongoDbRepository(IMongoDbContext mongoDbContext)
        {
            _collection = mongoDbContext.GetCollection<TEntity>();
        }

        public virtual Task Add(TEntity entity)
        {
            return _collection.InsertOneAsync(entity);
        }

        public virtual Task Update(TEntity entity)
        {
            var filter = new BsonDocument("_id", entity.Id);
            return _collection.ReplaceOneAsync(filter, entity);
        }

        public virtual Task Delete(string id)
        {
            return _collection.DeleteOneAsync(x => x.Id == id);
        }

        public virtual Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToListAsync();
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return _collection.AsQueryable().ToListAsync();
        }

        public virtual Task<TEntity> GetById(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual Task<long> Count()
        {
            return _collection.CountAsync(FilterDefinition<TEntity>.Empty);
        }
    }
}
