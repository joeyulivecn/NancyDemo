using MongoDB.Driver;
using Nancy.Demo.Data.Entities;
using Nancy.Demo.Data.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data.Repositories
{
    public class UserRepository : MongoDbRepository<User>
    {
        public UserRepository(TestDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
