using Nancy.Demo.Data.Entities;
using Nancy.Demo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task AddUser(User user)
        {
            return _userRepository.Insert(user);
        }

        public Task<List<User>> GetUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
