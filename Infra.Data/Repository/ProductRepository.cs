using Azure.Core;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task CreatProductAsync(Product product)
        {
            await _ctx.Products.AddAsync(product);
            await SaveAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetByIdAsync(id);
            _ctx.Products.Remove(product);
            await SaveAsync();
        }

        public IEnumerable<Product> GetProducts(int userId)
        {
            var products =  _ctx.Products.Where(p => p.UserId == userId);
            return products.AsEnumerable();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _ctx.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception(message:"این محصول پیدا نشد");
            }
            return product;
        }

        public async Task<bool> CheckExist(string number)
        {
            return await _ctx.Products.AnyAsync(p => p.ProductNumber == number);
        }
        public async Task<bool> CheckExist(int id)
        {
            return await _ctx.Products.AnyAsync(p => p.ProductId == id);
        }
        public async Task<Product> GetByNumber(string number)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(p => p.ProductNumber == number);
            if (product == null)
            {
                throw new Exception("این محصول پیدا نشد");
            }
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _ctx.Products
                .AsEnumerable();
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product Product)
        {
            var product = await _ctx.Products.FindAsync(Product.ProductId);
            if (product == null) 
            {
                throw new Exception("محصول پیدا نشد");
            }
            product.ProductName = Product.ProductName;
            product.ProductDescription = Product.ProductDescription;
            product.OrginalPrice = Product.OrginalPrice;
            product.Stock = Product.Stock;
            product.ImageUrl = Product.ImageUrl;

            await SaveAsync();
        }

        public async Task<List<Product>> GetByUser(int  userId)
        {
            var products = await _ctx.Products.Where(p => p.UserId == userId).ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetByCategory(int? CategoryId)
        {
            return await _ctx.Products.Where(p => p.CategoryId == CategoryId).ToListAsync();
        }

    }
}
