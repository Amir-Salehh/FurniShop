using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
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

        public bool CheckExist(string EmailMobile)
        {
            return _userRepository.CheckExistUser(EmailMobile);
        }

        public bool CheckLogin(string emailPhone, string password)
        {
            var user = _userRepository.GetUserByEmailOrMobile(emailPhone);
            
            string hashedPassword = PasswordHelper.HashPasswordBase64(password, user.saltpassword);

            return hashedPassword == user.Password;
        }

        public bool CheckUser(string email, string password)
        {
            return _userRepository.IsExistUser(email.Trim().ToLower(), password);
        }

        public void RegisterUser(User user)
        {
            _userRepository.CreateNewUser(user);
        }
    }
}
