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
        Task RegisterUserAsync(User user);
        Task<bool> CheckExistAsync(string EmailMobile);

        Task<string> CheckLoginAsync(string emailMobile, string password, bool remmemberMe);

        public List<User> GetUsers();

        public Task<User> GetUserById(int userId);





    }
}
