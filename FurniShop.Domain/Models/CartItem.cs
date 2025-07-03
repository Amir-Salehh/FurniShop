using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }

        // FK
        public int UserId { get; set; }
        public User user { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
    }
}
