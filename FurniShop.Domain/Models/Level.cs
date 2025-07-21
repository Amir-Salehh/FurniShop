using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }

        public string LevelName { get; set; } = null!;

        public decimal MinSales { get; set; }

        public decimal DiscountSharePercent { get; set; } 

    }
}
