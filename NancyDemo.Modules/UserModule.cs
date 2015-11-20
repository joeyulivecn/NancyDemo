using Nancy;
using NancyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Nancy.Demo.Data.Entities;
using Nancy.Responses;

namespace NancyDemo.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IUserService userService)
            : base("/api/v1/users")
        {
            Get["/", true] = async (parameters, cancellationToken) =>
            {
                var users = await userService.GetUsers();
                return users;
            };

            Post["/", true] = async (parameters, cancellationToken) =>
            {
                var user = this.Bind<User>();
                await userService.AddUser(user);
                return HttpStatusCode.Created;
            };
        }
    }
}
