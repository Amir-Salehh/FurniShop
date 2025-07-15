using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("ShoppingCart")]
        public int CartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public PaymentMethod paymentMethod { get; set; } = 0;
        public enum PaymentMethod
        {
            Wallet = 0,
            OnlineGateway = 1,
            CashOnDelivery = 2
        }

        public PaymentStatus paymentStatus { get; set; }
        public enum PaymentStatus
        {
            Pending = 0,
            Paid = 1,
            Failed = 2,
            Cancelled = 3,
            Refunded = 4,
        }

        public DateTime Payed { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        




    }
}
