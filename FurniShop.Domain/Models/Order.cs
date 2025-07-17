using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime Place_Order {  get; set; }

        public Decimal Total_Price { get; set; }

        public Order_Status OrderStatus { get; set; } = Order_Status.Pending;

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
    public enum Order_Status
    {
        Pending = 0,
        Paid = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Canceled = 5,
        Returned = 6,
        Failed = 7
    }
}
