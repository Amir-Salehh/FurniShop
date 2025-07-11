using FurniShop.Application.Security;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool CheckExistUser(string emailPhone)
        {
            bool checkEmail = _ctx.users.Any(u => u.Email == emailPhone);
            bool checkPhoneNumber = _ctx.users.Any(u => u.PhoneNumber == emailPhone);
            if (checkEmail || checkPhoneNumber)
            {
                return true;
            }
            else
                return false;
        }

        public void CreateNewUser(User user)
        {
            _ctx.users.Add(user);
            Save(); 
        }

        public void DeleteUser(int UserId)
        {
            var user = GetUserById(UserId);
            _ctx.users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>().AsEnumerable();
            return users;
        }

        public User? GetUserByEmailOrMobile(string emailMobile)
        {
            var user = _ctx.users.FirstOrDefault(u => u.Email == emailMobile || u.PhoneNumber == emailMobile);
            
            return user;
        }

        public User GetUserById(int Id)
        {
            var user = _ctx.users.Find(Id);
            return user;
        }

        public bool IsExistUser(string email, string phoneNumber)
        {
            return _ctx.users.Any(u => u.Email == email || u.PhoneNumber == phoneNumber);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var User = GetUserById(user.UserId);

            User.FullName = user.FullName;
            User.Email = user.Email;

            Save();
        }
    }
}
