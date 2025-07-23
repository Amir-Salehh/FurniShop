using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.Product
{
    public class DiscountCodeResponseDTo
    {
        public string Code { get; set; } = null!;
        public string? CodeName { get; set; }
        public string? Note { get; set; }

        public DateOnly StartedAt { get; set; }
        public DateOnly EndAt { get; set; }

        public int? CategoryId { get; set; }
        public decimal Discount { get; set; }

        public decimal Min_Order_Amount { get; set; }

        public List<int> ProductIds { get; set; } = null!;
    }
}
