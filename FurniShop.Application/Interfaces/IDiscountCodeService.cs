using FurniShop.Application.DTOs.Product;
using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Interfaces
{
    public interface IDiscountCodeService
    {
        public List<DiscountCode> GetAll();

        public Task Create(DiscountCodeRequest request);

        public Task<bool> CheckExist(string code);

        public void CheckDiscount(DiscountCodeType type, decimal Discount, List<Product> products);

        public Task<List<Product>> SelectProduct(int? categoryId, List<int> ProductIds, int userId);
    }
}
