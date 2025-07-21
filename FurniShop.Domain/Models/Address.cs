using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Address
    {
        [Key]
        public int Address_Id { get; set; }

        public string address { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }

    }
}
