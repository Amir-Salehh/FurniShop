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
        public IEnumerable<Category> Categories();

        public Category GetCategoryById(int Categoryid);

        public void CreateCategory(Category category);

        public void UpdateCategory(Category category);

        public void DeleteCategory(int Categoryid);

        public void Save();
    }
}
