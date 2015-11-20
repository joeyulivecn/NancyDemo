using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Nancy.Demo.Data.Entities
{
    public class User : MongoDbEntity
    {
        public string Name { get; set; }
    }
}
