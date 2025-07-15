using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class SellerPayout
    {
        public int PayoutId { get; set; }

        public int SellerId { get; set; }

        public decimal TotalEarning { get; set; }

        public decimal Bonus_From_Discounts { get; set; }

        public decimal Amount { get; set; }

        public DateTime PayoutAt { get; set; }

        public string PayoutMethod { get; set; }

        public Payout_Status PayoutStatus { get; set; }
        public enum Payout_Status
        {
            Pending = 0,
            Processing = 1,
            Paid = 2,
            Failed = 3,
            Canceled = 4,
            OnHold = 5,
            Rejected = 6,
        }

        public DateTime CreatedAt { get; set; }

        public string? Notes { get; set; }
    } 
}
