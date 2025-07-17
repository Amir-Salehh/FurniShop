using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task CreateCategory(Category category);

        public Task<bool> CheckExistCategory(string categoryName);
    }
}
