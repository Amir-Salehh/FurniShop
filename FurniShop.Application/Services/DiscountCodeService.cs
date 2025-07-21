using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Services
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly IDiscountCodeRepository _descountcoderepository;
        private readonly IProductRepository _productrepository ;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DiscountCodeService(IDiscountCodeRepository descountcoderepository, IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _descountcoderepository = descountcoderepository;
            _productrepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Create(DiscountCodeRequest request)
        {
            var isActive = request.StartedAt >= DateOnly.FromDateTime(DateTime.Now) &&
                           request.EndAt < DateOnly.FromDateTime(DateTime.Now);

            int userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(type: ClaimTypes.NameIdentifier).Value);

            var selectedProducts = SelectProduct(request.CategoryId, request.ProductIds, userId);

            CheckDiscount(request.DiscountType, request.Discount,await selectedProducts);

            var discountCode = new DiscountCode
            {
                Code = request.Code,
                CodeName = request.CodeName,
                Note = request.Note,

                StartedAt = request.StartedAt,
                EndAt = request.EndAt,
                IsActive = isActive,

                CategoryId = request.CategoryId,

                Products = await selectedProducts,

                Discount = request.Discount,

                SellerId = userId,

                CreatedAt = DateTime.Now,

                Min_Order_Amount = request.MinOrderAmount
            };

            await _descountcoderepository.Create(discountCode);
        }

        public void CheckDiscount(DiscountCodeType type, decimal Discount, List<Product> products)
        {
            if (type == DiscountCodeType.Persent)
            {
                if (Discount < 1 || Discount > 100)
                {
                    throw new Exception("کد تخفیف باید عددی بین 1و100 باشد");
                }
            }
            else if (type == DiscountCodeType.Fixed)
            {
                foreach (var product in products)
                {
                    if (Discount > product.OrginalPrice)
                    {
                        throw new Exception("مقدار تخفیف از یکی از محصولات کمتر است" + product.ProductName);
                    }
                }
            }
        }

        public async Task<List<Product>> SelectProduct(int? categoryId, List<int> ProductIds, int userId)
        {

            var sellerProducts = await _productrepository.GetByUser(userId);

            var productsId = ProductIds;

            List<Product> selectedProducts;

            if (categoryId != null)
            {
                selectedProducts = sellerProducts.Where(p => p.CategoryId == categoryId).ToList();

                if (!selectedProducts.Any())
                {
                    throw new Exception("شما دراین دسته بندی محصولی ندارید");
                }

                return selectedProducts;
            }
            else
            {
                selectedProducts = sellerProducts.Where(p => productsId.Contains(p.ProductId)).ToList();

                if (!productsId.All(id => sellerProducts.Any(p => p.ProductId == id)))
                {
                    throw new Exception("فقط مجاز به انتخاب محصولات خود هستید");
                }

                return selectedProducts;
            }

        }

        public List<DiscountCode> GetAll()
        {
            return _descountcoderepository.GetAll().ToList();
        }

        public async Task<bool> CheckExist(string code)
        {
            return await _descountcoderepository.CheckExist(code);
        }
    }
}
