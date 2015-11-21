using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Demo.Data.Framework.Repositories;
using Nancy.Demo.Domain.Entities;
using Nancy.Demo.Domain.Interfaces;

namespace Nancy.Demo.Data.Repositories
{
    public class ActivityRepository : MongoDbRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(TestDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
