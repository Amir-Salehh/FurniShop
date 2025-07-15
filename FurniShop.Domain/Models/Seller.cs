using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Seller
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        public ICollection<BankCartInformation> Banks { get; set; }
    }
}
