using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public Status status { get; set; }


        public enum Status
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
}
