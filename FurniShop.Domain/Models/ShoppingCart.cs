using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ShoppingCart
    {
        public int Cart_Id { get; set; }

        [ForeignKey("Buyer")]
        public int Buy_User_Id { get; set; }
        public Buyer Buyer { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public ICollection<CartItem> Cart_Items { get; set; }

    }
}
