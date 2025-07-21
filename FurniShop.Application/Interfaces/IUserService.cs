using FurniShop.Application.DTOs.Auth;
using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> CheckUserAsync(string email, string PhoneNumber);
        Task RegisterUserAsync(RegisterRequest request);
        Task<bool> CheckExistAsync(string EmailMobile);

        public Task<string> CheckLoginAsync(LoginRequest request);

        public List<User> GetUsers();

        public Task<User> GetUserById(int userId);





    }
}
