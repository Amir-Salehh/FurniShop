using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.Product
{
    public class DiscountCodeRequest
    {
        [Required]
        public string Code { get; set; } = null!;
        public string? CodeName { get; set; }
        public string? Note { get; set; }

        [Required]
        public DateOnly StartedAt { get; set; }

        [Required]
        public DateOnly EndAt { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public DiscountCodeType DiscountType { get; set; } = DiscountCodeType.Persent;

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public decimal MinOrderAmount { get; set; }

        [Required]
        public int UsedCount { get; set; } = 0;

        [Required]
        public List<int> ProductIds { get; set; } = null!;


    }


    public enum DiscountCodeType
    {
        Persent = 0,
        Fixed = 1,
    }

}
