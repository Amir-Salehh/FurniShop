using FurniShop.Application.ViewModels;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User GetUserById(int Id)
        {
            var user = _ctx.users.Find(Id);
            return user;
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
