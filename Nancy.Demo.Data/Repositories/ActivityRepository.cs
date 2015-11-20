using Nancy.Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Demo.Data.Framework.Repositories;

namespace Nancy.Demo.Data.Repositories
{
    public class ActivityRepository : MongoDbRepository<Activity>
    {
        public ActivityRepository()
            : base(new TestDbContext())
        {

        }
    }
}
