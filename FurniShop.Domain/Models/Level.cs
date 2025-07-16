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

        public string LevelDetail { get; set; } = null!;

        public string MinSales { get; set; } = null!;

        public decimal Discount_Percent { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }
    }
}
