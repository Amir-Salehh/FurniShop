using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Buyer
    {
        [Key,ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; } = null!;
    }
}
