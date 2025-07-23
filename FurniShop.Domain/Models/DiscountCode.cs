using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class DiscountCode
    {
        [Key]
        public int DiscountCodeId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public int SellerId { get; set; }

        public string Code { get; set; } = null!;

        public decimal Discount {  get; set; }

        public int UsedCount { get; set; } = 0 ;

        public DateOnly StartedAt { get; set; }

        public DateOnly EndAt { get; set; }

        public bool IsActive { get; set; } = false ;

        public DateTime CreatedAt { get; set; }

        public decimal Min_Order_Amount { get; set; }

        public string? CodeName { get; set; }

        public string? Note { get; set; }

        public List<int> Products { get; set; } = null!;

        public ICollection<Product_DiscountCode> Product_DiscountCode { get; set; }


    }
}
