using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Data
{
    public interface IEntity<Tkey>
    {
        Tkey Id { get; set; }
    }

    public interface IEntity : IEntity<string>
    {
        string Id { get; set; }
    }
}
