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
        public User GetUserById(int Id);
        public void CreateNewUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int Id);
        public void Save();
        public bool IsExistUser(string email, string password);
    }
}
