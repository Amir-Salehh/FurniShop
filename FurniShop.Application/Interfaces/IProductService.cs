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
        public List<Product> GetProducts();

        public Task CreateProductAsync (Product product);

        public Task UpdateProductAsync (Product product);

        public Task DeleteProduct (int productId);

        public Task<bool> CheckExistProductAsync(string ProductNumber);

        public string GenerateProductNumber(int length = 5);

        public decimal AddDiscount(decimal OrginalPrice, decimal? Discount, DiscountType DiscountType);
    }
}
