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

        public virtual Task AddAsync(TEntity entity)
        {
            return _collection.InsertOneAsync(entity);
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            var filter = new BsonDocument("_id", entity.Id);
            return _collection.ReplaceOneAsync(filter, entity);
        }

        public virtual Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(x => x.Id == id);
        }

        public virtual Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, int limit, int offset,
            Expression<Func<TEntity, object>> sortKeySelector, bool ascending = true)
        {
            var sortDefinition = ascending ? Builders<TEntity>.Sort.Ascending(sortKeySelector)
                : Builders<TEntity>.Sort.Descending(sortKeySelector);
            var options = new FindOptions<TEntity> { Limit = limit, Skip = offset, Sort = sortDefinition };
            using (var cursor = await _collection.FindAsync<TEntity>(filter, options))
            {
                return await cursor.ToListAsync();
            }
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return _collection.AsQueryable().ToListAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(string id)
        {
            return _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual Task<long> CountAsync()
        {
            return _collection.CountAsync(FilterDefinition<TEntity>.Empty);
        }
    }
}
