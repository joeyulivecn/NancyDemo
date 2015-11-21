using Nancy.Demo.Domain.Entities;
using Nancy.Demo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task AddUser(User user)
        {
            return _userRepository.Add(user);
        }

        public Task<List<User>> GetUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
