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
    public class ProductRepository : IProductRepository
    {
        private readonly FurniShopDbContext _ctx;
        public ProductRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public void CreatProduct(Product product)
        {
            _ctx.Products.Add(product);
            Save();
        }

        public void DeleteProduct(int id)
        {
            var product = GetById(id);
            _ctx.Products.Remove(product);
            Save();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            return products.AsEnumerable();
        }

        public Product GetById(int id)
        {
            var product = _ctx.Products.Find(id);
            return product;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void UpdateProduct(Product Product)
        {
            var product = _ctx.Products.Find(Product.ProductId);

            product.ProductName = Product.ProductName;
            product.ProductDescription = Product.ProductDescription;
            product.Price = Product.Price;
            product.Stock = Product.Stock;
            product.ImageUrl = Product.ImageUrl;

            Save();
        }
    }
}
