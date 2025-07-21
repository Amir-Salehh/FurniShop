using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FurniShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService (IProductRepository productRepository, ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor)
        {

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CheckExistProductAsync(string ProductNumber)
        {
            return await _productRepository.CheckExist(ProductNumber);
        }
        public async Task<bool> CheckExistProductAsync(int ProductId)
        {
            return await _productRepository.CheckExist(ProductId);
        }

        public async Task CreateProductAsync(ProductRequest request)
        {
            var category = await _categoryRepository.GetCategoryByName(request.CategoryName);

            var DiscountedPrice = AddDiscount(request.OrginalPrice, request.Discount, request.DiscountType);

            int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(type: ClaimTypes.NameIdentifier).Value);

            var product = new Product
            {
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                ProductNumber = request.ProductNumber,
                Stock = request.Stock,
                OrginalPrice = request.OrginalPrice,
                Discount = request.Discount,
                DiscountedPrice = DiscountedPrice,
                ImageUrl = request.ImageUrl,
                UserId = userId,
                CategoryId = category.CategoryId
            };

            await _productRepository.CreatProductAsync(product);
        }

        public async Task DeleteProduct (int productId)
        {
            await _productRepository.DeleteProduct(productId);
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

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public async Task<List<Product>> GetYourProducts(int UserId)
        {
            var products = await _productRepository.GetByUser(UserId);
            return products;
        }
    }
}
