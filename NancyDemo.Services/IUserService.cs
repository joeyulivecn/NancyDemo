using Nancy.Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task AddUser(User user);
    }
}
