using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FurniShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService (IProductRepository productRepository, ICategoryRepository categoryRepository, 
                               IHttpContextAccessor httpContextAccessor, IAttributeRepository attributeRepository)
        {

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _attributeRepository = attributeRepository;
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

            int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(type: ClaimTypes.NameIdentifier)!.Value);

            List<int> attributeIds = new() ;
            if(request.AtributeName!.Count != 0)
            {
                attributeIds = await CreateAttribute(request.AtributeName!);
            }

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
                CategoryId = category.CategoryId,
                ProductAttributes = new List<ProductAttribute>()
            };


            if (request.AtributeName?.Count > 0)
            {
                for (int i = 0; i < attributeIds.Count; i++)
                {
                        product.ProductAttributes.Add(new ProductAttribute
                        {
                            AttributeId = attributeIds[i],
                            Value = request.AtributeValue![i]
                        });
                }
            }
            else
            {
                product.ProductAttributes = null;
            }

                await _productRepository.CreatProductAsync(product);

        }

        public async Task<List<int>> CreateAttribute(List<string> name)
        {
            List<int> attributeIds = new List<int>();
            foreach(var nameItem in name)
            {
                bool existAttribute = await _attributeRepository.CheckExist(nameItem);
                if (existAttribute)
                {
                    continue;
                }

                var attribute = new Attributes
                {
                    Name = nameItem,
                };

                await _attributeRepository.Create(attribute);

                attributeIds.Add(attribute.AttributeId);
            }

            return attributeIds;
            
        }


        public async Task DeleteProduct (int productId)
        {
            if (_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)!.Value == "Seller")
            {
                var hasProduct = await _productRepository.GetByUser(productId);
                if (hasProduct == null)
                {
                    throw new Exception("شما همچین محصولی ندارید");
                }
            }

            await _productRepository.DeleteProduct(productId);
        }

        public decimal AddDiscount(decimal OrginalPrice, decimal? discount, DiscountType DiscountType)
        {
            if (discount == null || discount == 0)
                return OrginalPrice;

            if (Equals(DiscountType, DiscountCodeType.Fixed))
            {
                return OrginalPrice - discount.Value;
            }
            else if (Equals(DiscountType, DiscountCodeType.Persent))
            {
                return OrginalPrice - (OrginalPrice * (discount.Value / 100));
            }
            else
            {
                return OrginalPrice;
            }

        }

        public async Task UpdateProductAsync(int id, ProductRequest request)
        {
            var product = await _productRepository.GetByIdAsync(id);

            var category = await _categoryRepository.GetCategoryByName(request.CategoryName);

            var DiscountedPrice = AddDiscount(request.OrginalPrice, request.Discount, request.DiscountType);

            List<int> attributeIds = new();
            if (request.AtributeName!.Count != 0)
            {
                attributeIds = await CreateAttribute(request.AtributeName!);
            }

            product.ProductName = request.ProductName;
            product.ProductDescription = request.ProductDescription;
            product.ProductNumber = request.ProductNumber;
            product.OrginalPrice = request.OrginalPrice;
            product.Discount = request.Discount;
            product.Stock = request.Stock;
            product.ImageUrl = request.ImageUrl;


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
