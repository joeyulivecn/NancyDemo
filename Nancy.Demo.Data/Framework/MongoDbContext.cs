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
        private string _connectionStringName;
        private IMongoDatabase _database;

        public string ConnectionStringName { get { return _connectionStringName; } }

        public MongoDbContext(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
            var setting = ConfigurationManager.ConnectionStrings[connectionStringName];
            var mongoUrl = new MongoUrl(setting.ConnectionString);
            var client = new MongoClient(mongoUrl);
            _database = client.GetDatabase(mongoUrl.DatabaseName);
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
