using Nancy.Demo.Domain.Entities;
using Nancy.Demo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task AddActivity(Activity activity)
        {
            return _activityRepository.AddAsync(activity);
        }
    }
}
