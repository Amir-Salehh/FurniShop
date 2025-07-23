using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Product_DiscountCode
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CodeId { get; set; }
        public DiscountCode DiscountCode { get; set; }

    }
}
