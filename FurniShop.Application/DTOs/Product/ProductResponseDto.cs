using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.Product
{
    public class ProductResponseDto
    {
        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public decimal OrginalPrice { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public decimal? Discount { get; set; }

        public string ProductNumber { get; set; } = null!;

        public List<string>? AtributeName { get; set; }
        public List<string>? AtributeValue { get; set; }

    }
}
