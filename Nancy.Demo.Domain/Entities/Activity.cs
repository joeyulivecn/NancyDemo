using Nancy.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.Demo.Domain.Entities
{
    public class Activity : MongoDbEntity
    {
        public Activity()
        {
            Comments = new List<ActivityComment>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public List<ActivityComment> Comments { get; set; }
    }

    public class ActivityComment
    {
        public string SubmittedBy { get; set; }

        public string Text { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
