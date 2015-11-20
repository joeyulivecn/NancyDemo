using Nancy.Demo.Data.Entities;
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
        private ActivityRepository _activityRepository;

        public ActivityService(ActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task AddActivity(Activity activity)
        {
            return _activityRepository.Add(activity);
        }
    }
}
