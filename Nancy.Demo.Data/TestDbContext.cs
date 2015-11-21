using Nancy.Demo.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data
{
    public class TestDbContext : MongoDbContext
    {
        public TestDbContext() : base("TestDbContext")
        {

        }
    }
}
