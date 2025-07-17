using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts(int userId);
        public IEnumerable<Product> GetAll();

        public Task<Product> GetByIdAsync(int id);
        public Task<Product> GetByNumber(string number);

        public Task CreatProductAsync(Product product);

        public Task UpdateProduct(Product product);

        public Task DeleteProduct(int id);

        public Task SaveAsync();
    }
}
