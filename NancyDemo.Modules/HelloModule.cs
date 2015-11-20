using Nancy;
using Nancy.Responses;
using NancyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Security;

namespace NancyDemo.Modules
{
    public class HelloModule : NancyModule
    {
        public HelloModule(IMyService myService)
        {
            this.RequiresAuthentication();
            this.RequiresClaims(new string[] { "admin1" });

            Before += ctx => {
                return null;
            };

            Get["/Hello"] = parameters =>
            {
                return "Hello " + myService.GetMessage();
            };

            Get["/users"] = parameters =>
            {
                return Response.AsJson(GetAllUsers());
            };
        }

        private IList<dynamic> GetAllUsers()
        {
            return new List<dynamic>
                {
                    new {Name = "Eric", SecondName = "Cartman", Age = 9},
                    new {Name = "Kenny", SecondName = "McCormick", Age = 9},
                    new {Name = "Kyle", SecondName = "Broflovski", Age = 9},
                    new {Name = "Stan", SecondName = "Marsh", Age = 9},
                    new {Name = "Butters", SecondName = "Stotch", Age = 9}
                };
        }
    }
}