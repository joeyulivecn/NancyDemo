using Nancy;
using NancyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Nancy.Responses;
using Newtonsoft.Json;
using Nancy.Demo.Domain.Interfaces;
using Nancy.Demo.Domain.Entities;
using System.IO;

namespace NancyDemo.Modules
{
    public class UserModule : NancyModule
    {
        public UserModule(IUserService userService, IUserRepository userRepository)
            : base("/api/v1/users")
        {
            Before += ctx =>
            {
                return null;
            };

            Get["/", true] = async (_, token) =>
            {
                var users = await userService.GetUsers();
                return users;
            };

            // ?fiter={condition}&limit={limit}&offset={offset}
            Get["/", ctx => ctx.Request.Url.Query != string.Empty, true] = async (_, token) =>
            {
                string filterString = this.Request.Query.filter;
                var filter = JsonConvert.DeserializeObject<dynamic>(filterString);

                int limit = this.Request.Query.limit;
                int offset = this.Request.Query.offset;

                var users = await userRepository.Get(u => true, limit, offset, u => u.Name, true);
                return users;
            };

            Post["/", true] = async (_, token) =>
            {
                //using (var sr = new StreamReader(this.Request.Body))
                //{
                //    var json = sr.ReadToEnd();
                //}
                var user = this.Bind<User>();
                await userService.AddUser(user);
                return HttpStatusCode.Created;
            };

            Put["/{id}", true] = async (_, token) =>
            {
                var user = this.Bind<User>();
                await userRepository.Update(user);
                return HttpStatusCode.OK;
            };

            Delete["/{id}", true] = async (_, token) =>
            {
                await userRepository.Delete(_.id);
                return HttpStatusCode.OK;
            };

            Options["/"] = route => new Response();
        }
    }
}
