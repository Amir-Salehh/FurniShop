using FurniShop.Application.DTOs.Product;
using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Task<List<Product>> GetYourProducts(int UserId);

        public Task CreateProductAsync (ProductRequest request);

        public Task UpdateProductAsync(int id, ProductRequest request);

        public Task DeleteProduct (int productId);

        public Task<bool> CheckExistProductAsync(string ProductNumber);
        public Task<bool> CheckExistProductAsync(int ProductId);

        public decimal AddDiscount(decimal OrginalPrice, decimal? Discount, DiscountType DiscountType);
    }
}
