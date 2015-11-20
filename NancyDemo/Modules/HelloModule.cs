using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo.Modules
{
    public class AHelloModule : NancyModule
    {
        public AHelloModule()
        {
            Get["/{cat}"] = parameters => "Hello World" + parameters.cat;
        }
    }
}