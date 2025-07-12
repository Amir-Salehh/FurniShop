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
        public IEnumerable<Product> GetAll();

        public Product GetById(int id);

        public void CreatProduct(Product product);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int id);

        public void Save();
    }
}
