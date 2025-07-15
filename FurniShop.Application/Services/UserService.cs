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

        public async Task<bool> CheckExistAsync(string EmailMobile)
        {
            return await _userRepository.CheckExistUserAsync(EmailMobile);
        }

        public async Task<(bool IsValid, User? user)> CheckLoginAsync(string emailPhone, string password)
        {
            var user = await _userRepository.GetUserByEmailOrMobileAsync(emailPhone);

            if (user == null)
                return (false, null);

            string hashedPassword = PasswordHelper.HashPasswordBase64(password.Trim(), user.saltpassword);

            bool IsValid = string.Equals(hashedPassword, user.Password, StringComparison.Ordinal);

            return (IsValid, user);
        }

        public async Task<bool> CheckUserAsync(string email, string PhoneNumber)
        {
            return await _userRepository.IsExistUserAsync(email.Trim().ToLower(), PhoneNumber);
        }

        public void RegisterUser(User user)
        {
            _userRepository.CreateNewUserAsync(user);
        }
    }
}
