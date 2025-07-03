using FurniShop.Application.Interfaces;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsExistUser(string email, string password)
        {
            return IsExistUser(email.Trim().ToLower(), password);
        }

        public int RegisterUser(User user)
        {
 

            _userRepository.CreateNewUser(user);
            return user.UserId;
        }
    }
}
