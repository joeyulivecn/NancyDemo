using Nancy;
using NancyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using System.IO;
using Nancy.Demo.Domain.Entities;

namespace NancyDemo.Modules
{
    public class ActivityModule : NancyModule
    {
        public ActivityModule(IActivityService activityService)
        {
            Post["activities"] = parameters => {

                //using (var sr = new StreamReader(this.Request.Body))
                //{
                //    var json = sr.ReadToEnd();
                //}

                var activity = this.Bind<Activity>();
                activityService.AddActivity(activity);
                return HttpStatusCode.Created;
            };
        }
    }
}
