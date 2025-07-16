using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class SellerPayout
    {
        [Key]
        public int PayoutId {  get; set; }

        [ForeignKey("Seller")]
        public int SellerId {  get; set; }

        public decimal TotalEarnings { get; set; }

        public decimal Bonus_From_Discounts { get; set; }

        public decimal Amount { get; set; }

        public DateTime PayoutAt { get; set; }

        public payoutMethod PayoutMethod { get; set; } = payoutMethod.BankTransfer;
        
        public payoutStatus payoutStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Note { get; set; }

    }

    public enum payoutMethod
    {
        BankTransfer = 0,
        CreditToWallet = 1,
    }

    public enum payoutStatus
    {
        Pending = 0,      
        Approved = 1,     
        Rejected = 2, 
        Processing = 3,  
        Completed = 4,     
        Failed = 5        
    }
}
