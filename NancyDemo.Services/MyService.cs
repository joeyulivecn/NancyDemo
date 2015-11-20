using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public class MyService : IMyService
    {
        public MyService()
        {

        }

        public string GetMessage()
        {
            return "My My";
        }
    }
}
