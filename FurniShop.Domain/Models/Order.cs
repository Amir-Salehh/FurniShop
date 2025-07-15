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

        [ForeignKey("Buyer")]
        public int Buy_User_Id { get; set; }
        public Buyer Buyer { get; set; }

        public DateTime Place_Order {  get; set; }

        public Decimal Total_Price { get; set; }

        public Order_Status OrderStatus { get; set; } = Order_Status.Pending;
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

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
