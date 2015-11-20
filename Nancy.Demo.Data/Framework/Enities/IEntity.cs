using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data
{
    public interface IEntity
    {
        [BsonId]
        string Id { get; set; }
    }
}
