using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class UserRoles
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Roles Role { get; set; }

    }
}
