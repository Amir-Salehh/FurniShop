using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Cart_Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public ICollection<CartItem> Cart_Items { get; set; } = null!;

    }
}
