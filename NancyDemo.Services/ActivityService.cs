using Nancy.Demo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public class ActivityService : IActivityService
    {
        public Task AddActivity(Nancy.Demo.Data.Entities.Activity activity)
        {
            var rep = new ActivityRepository();
            return rep.Insert(activity);
        }
    }
}
