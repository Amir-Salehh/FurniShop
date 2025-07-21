using Azure.Core;
using FurniShop.Application.Security;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FurniShopDbContext _ctx;
        public UserRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CheckExistUserAsync(string emailPhone)
        {
            bool checkEmail = await _ctx.Users.AnyAsync(u => u.Email == emailPhone);
            bool checkPhoneNumber = await _ctx.Users.AnyAsync(u => u.PhoneNumber == emailPhone);
            if (checkEmail || checkPhoneNumber)
            {
                return true;
            }
            else
                return false;
        }

        public async Task CreateNewUserAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
            await SaveAsync();

        }

        public async Task DeleteUserAsync(int UserId)
        {
            var user = await GetUserByIdAsync(UserId);
            _ctx.Users.Remove(user);
            await SaveAsync();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _ctx.Users.AsEnumerable();
            return users;
        }

        public async Task<User?> GetUserByEmailOrMobileAsync(string emailMobile)
        {
            var user = await _ctx.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.Email == emailMobile || u.PhoneNumber == emailMobile);
            

            return user;
        }

        public async Task<User?> GetUserByIdAsync(int Id)
        {
            var user = await _ctx.Users.FindAsync(Id);

            return user;
        }

        public async Task<bool> IsExistUserAsync(string email, string phoneNumber)
        {
            return await _ctx.Users.AnyAsync(u => u.Email == email || u.PhoneNumber == phoneNumber);
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var User = await GetUserByIdAsync(user.UserId);

            User.FullName = user.FullName;
            User.Email = user.Email;

            await SaveAsync();
        }
    }
}
