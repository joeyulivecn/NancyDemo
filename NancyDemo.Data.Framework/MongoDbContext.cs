using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data.Framework
{
    public abstract class MongoDbContext : IMongoDbContext
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoDatabase Database
        {
            get { return _database; }
        }

        public MongoDbContext(string connectionStringName)
        {
            var setting = ConfigurationManager.ConnectionStrings[connectionStringName];
            var mongoUrl = new MongoUrl(setting.ConnectionString);
            _client = new MongoClient(mongoUrl);
            _database = _client.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }

        public virtual void RegisterClassMap()
        {

        }
    }
}