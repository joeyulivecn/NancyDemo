using Nancy.Demo.Data.Framework.Repositories;
using Nancy.Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Domain.Interfaces
{
    public interface IActivityRepository : IRepository<Activity>
    {
    }
}
