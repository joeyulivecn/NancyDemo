using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data.Framework
{
    public interface IMongoDbContext
    {
        void RegisterClassMap();

        IMongoClient Client { get; }

        IMongoDatabase Database { get; }

        IMongoCollection<TEntity> GetCollection<TEntity>();
    }
}