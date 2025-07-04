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
        bool CheckUser(string email, string password);
        void RegisterUser(User user);
    }
}
