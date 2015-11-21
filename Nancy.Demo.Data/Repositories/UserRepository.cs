using Nancy.Demo.Data.Framework.Repositories;
using Nancy.Demo.Domain.Entities;
using Nancy.Demo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data.Repositories
{
    public class UserRepository : MongoDbRepository<User>, IUserRepository
    {
        public UserRepository(TestDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
