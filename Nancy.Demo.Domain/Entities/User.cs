using Nancy.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Domain.Entities
{
    public class User : MongoDbEntity
    {
        public string Name { get; set; }
    }
}
