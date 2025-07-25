using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface IProductDiscountCodeRepository
    {
        public Task<Product_DiscountCode> GetByDiscountCodId(int id);
    }
}
