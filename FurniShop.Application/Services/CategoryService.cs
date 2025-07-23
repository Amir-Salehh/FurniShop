using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            var categorie = _categoryRepository.GetAllCategories();
            return categorie.ToList();
        }

        public async Task<bool> CheckExistCategoryById(int categoryId)
        {
            return await _categoryRepository.CheckExistCategoryById(categoryId);
        }

        public async Task CreateCategory(CategoryRequest request)
        {
            var category = new Category
            {
                Name = request.CategoryName,
            };

            await _categoryRepository.CreateCategory(category);
        }

        public async Task DeleteCategory(int categoryId)
        {

            await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task UpdateCategory(int categoryId, string CategoryName)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            category.Name = CategoryName;

            await _categoryRepository.UpdateCategory(category);
        }

        public async Task<bool> CheckExistCategoryByName(string categoryName)
        {
            return await _categoryRepository.CheckExistCategoryByName(categoryName);

        }

    }
}
