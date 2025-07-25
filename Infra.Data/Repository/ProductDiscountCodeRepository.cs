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
    internal class ProductDiscountCodeRepository : IProductDiscountCodeRepository
    {
        private readonly FurniShopDbContext _ctx;
        public ProductDiscountCodeRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product_DiscountCode> GetByDiscountCodId(int id)
        {
            var product_DiscountCode = await _ctx.Product_DiscountCode.FindAsync(id);
            return product_DiscountCode!;
        }
    }
}
