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
using Nancy.Demo.Data.Repositories;

namespace NancyDemo.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IUserService userService, UserRepository userRepository)
            : base("/api/v1/users")
        {
            Get["/", true] = async (param, cancellationToken) =>
            {
                var users = await userService.GetUsers();
                return users;
            };

            Post["/", true] = async (param, cancellationToken) =>
            {
                var user = this.Bind<User>();
                await userService.AddUser(user);
                return HttpStatusCode.Created;
            };

            Put["/{id}", true] = async (param, cancellationToken) =>
            {
                var user = this.Bind<User>();
                await userRepository.Update(user);
                return HttpStatusCode.OK;
            };

            Delete["/{id}", true] = async (param, cancellationToken) =>
            {
                await userRepository.Delete(param.id);
                return HttpStatusCode.OK;
            };
        }
    }
}
