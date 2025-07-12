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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FurniShopDbContext _ctx;
        public CategoryRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;   
        }

        public IEnumerable<Category> Categories()
        {
            var categories = new List<Category>();
            return categories;
        }

        public void CreateCategory(Category category)
        {
            _ctx.categories.Add(category);
            Save();
        }

        public void DeleteCategory(int Categoryid)
        {
            var category = GetCategoryById(Categoryid);
            _ctx.categories.Remove(category); 
            Save();
        }

        public Category GetCategoryById(int Categoryid)
        {
            var category = _ctx.categories.Find(Categoryid);
            return category;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void UpdateCategory(Category Category)
        {
            var category = GetCategoryById(Category.CategoryId);

            category.Name = Category.Name;

            Save();

        }
    }
}
