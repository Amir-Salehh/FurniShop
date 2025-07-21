using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("Level")]
        public int LevelId { get; set; }

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public byte[] saltpassword { get; set; } = null!;  

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        public ICollection<Address>? Addresses { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; } = null!;

    }
}
