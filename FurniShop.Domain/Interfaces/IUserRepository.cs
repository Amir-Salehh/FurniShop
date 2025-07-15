using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public Task<User?> GetUserByIdAsync(int Id);
        public Task<User?> GetUserByEmailOrMobileAsync(string emailMobile);
        public Task CreateNewUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(int Id);
        public Task SaveAsync();
        public Task<bool> IsExistUserAsync(string email, string mobilePhone);
        public Task<bool> CheckExistUserAsync(string emailPhone);
    }
}
