using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string? Neighborhood { get; set; } 
        public string Street { get; set; }
        public string? Alley { get; set; }
        public string Plaque { get; set; }
        public string? Unit { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }

        // FK
        public int UserId { get; set; }
        public User user { get; set; }

    }
}
