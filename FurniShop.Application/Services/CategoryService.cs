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

        public async Task<bool> CheckExistCategory(string categcoryName)
        {
            if(!await _categoryRepository.GetCategoryByName(categcoryName))
            {
                return false;
            }
            return true;
        }

        public async Task CreateCategory(Category category)
        {
            await _categoryRepository.CreateCategory(category);
        }
    }
}
