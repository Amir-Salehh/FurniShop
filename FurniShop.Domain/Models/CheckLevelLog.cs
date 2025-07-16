using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurniShop.Domain.Models
{
    public class CheckLevelLog
    {
        [Key]
        public int Log_Id { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; } = null!;

        public decimal Total_Sales_This_Month { get; set; }

        public bool Can_Upgrade { get; set; }

        public DateTime Checked_At { get; set; }

        public DateTime Updated_At { get; set; }
    }
}
