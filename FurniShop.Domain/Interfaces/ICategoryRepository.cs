using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories();

        public Task CreateCategory(Category category);

        public Task<Category?> GetCategoryById(int CategoryId);

        public Task UpdateCategory(Category category);

        public Task DeleteCategory(int CategoryId);

        public Task Save();

        Task<Category> GetCategoryByName(string categcoryName);

        Task<bool> CheckExistCategoryByName(string categoryName);
        Task<bool> CheckExistCategoryById(int categoryId);
    }
}
