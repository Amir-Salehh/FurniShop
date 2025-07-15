using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class BankCartInformation
    {
        [Key]
        public int CartId { get; set; }

        public string CartNumber { get; set; } = null!;

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public string BankName { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
