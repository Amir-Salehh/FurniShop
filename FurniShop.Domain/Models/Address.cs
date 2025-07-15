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

        public string Province { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? Neighborhood { get; set; } 

        public string Street { get; set; } = null!;

        public string? Alley { get; set; }

        public string Plaque { get; set; } = null!;

        public string? Unit { get; set; }

        public string PostalCode { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }

    }
}
