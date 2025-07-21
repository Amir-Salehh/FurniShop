using FurniShop.Application.DTOs.Product;
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
        public Task CreateCategory(CategoryRequest request);

        public Task<bool> CheckExistCategoryById(int categoryId);
        public Task<bool> CheckExistCategoryByName(string categoryName);

        public List<Category> GetAll();

        public Task DeleteCategory(int categoryId);

        public Task UpdateCategory(int categoryId, string CategoryName);
    }
}
