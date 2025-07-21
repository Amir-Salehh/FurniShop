using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FurniShopDbContext _ctx;
        public CategoryRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;   
        }

        public async Task<bool> CheckExistCategoryByName(string categoryName)
        {
            return await _ctx.Categories.AnyAsync(c => c.Name == categoryName);
        }
        public async Task<bool> CheckExistCategoryById(int categoryId)
        {
            return await _ctx.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }

        public async Task CreateCategory(Category category)
        {
            await _ctx.Categories.AddAsync(category);
            await Save();
        }

        public async Task DeleteCategory(int CategoryId)
        {
            var category = await GetCategoryById(CategoryId);
            if (category == null) 
            {
                throw new Exception("این دسته بندی وجود ندارد");
            }
            _ctx.Categories.Remove(category);
            await Save();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _ctx.Categories.AsEnumerable();
        }

        public async Task<Category?> GetCategoryById(int CategoryId)
        {
            var Category = await _ctx.Categories.FindAsync(CategoryId);

            return Category;
        }

        public async Task<Category> GetCategoryByName(string categcoryName)
        {
            var category = await _ctx.Categories.FirstOrDefaultAsync(c => c.Name == categcoryName);

            return category;
        }

        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _ctx.Categories.Update(category);

            await Save();
        }

    }
}
