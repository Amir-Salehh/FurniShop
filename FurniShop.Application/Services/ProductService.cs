using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;

namespace FurniShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> CheckExistProductAsync(string ProductNumber)
        {
            var product = await _productRepository.GetByNumber(ProductNumber);

            return true;
        }

        public async Task CreateProductAsync(Product product)
        {
                await _productRepository.CreatProductAsync(product);
        }

        public async Task DeleteProduct (int productId)
        {
            await _productRepository.DeleteProduct(productId);
        }

        public string GenerateProductNumber(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products.ToList();
        }

        public decimal AddDiscount(decimal OrginalPrice, decimal? discount, DiscountType DiscountType)
        {
            if (discount == null || discount == 0)
                return OrginalPrice;

            return DiscountType switch
            {
                DiscountType.None => OrginalPrice,
                DiscountType.Fixed => OrginalPrice - discount.Value,
                DiscountType.Persent => OrginalPrice - (OrginalPrice * (discount.Value / 100)),
                _ => OrginalPrice
            };

        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }
    }
}
