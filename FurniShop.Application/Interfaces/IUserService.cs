using FurniShop.Application.ViewModels;
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
        Task<bool> CheckExistAsync(string EmailMobile);
        void RegisterUser(User user);
        Task<(bool IsValid, User? user)> CheckLoginAsync(string emailMobile, string password);
    }
}
