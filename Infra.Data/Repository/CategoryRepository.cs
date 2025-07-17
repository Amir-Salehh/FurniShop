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

        public async Task CreateCategory(Category category)
        {
            await _ctx.Categories.AddAsync(category);
            await Save();
        }

        public async Task DeleteCategory(int CategoryId)
        {
            var category = await GetCategoryById(CategoryId);
            _ctx.Categories.Remove(category);
            await Save();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return new List<Category>().AsEnumerable();
        }

        public async Task<Category?> GetCategoryById(int CategoryId)
        {
            var Category = await _ctx.Categories.FindAsync(CategoryId);

            return Category;
        }

        public async Task<bool> GetCategoryByName(string categcoryName)
        {
            return await _ctx.Categories.AnyAsync(c => c.Name == categcoryName);
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
