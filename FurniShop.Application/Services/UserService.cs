using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public bool CheckLogin(string emailPhone, string password, out User user)
        {
            user = _userRepository.GetUserByEmailOrMobile(emailPhone);

            if (user == null)
                return false;

            string hashedPassword = PasswordHelper.HashPasswordBase64(password.Trim(), user.saltpassword);

            return string.Equals(hashedPassword, user.Password, StringComparison.Ordinal);
        }

        public bool CheckUser(string email, string PhoneNumber)
        {
            return _userRepository.IsExistUser(email.Trim().ToLower(), PhoneNumber);
        }

        public void RegisterUser(User user)
        {
            _userRepository.CreateNewUser(user);
        }
    }
}
