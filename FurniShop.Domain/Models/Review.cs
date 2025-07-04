using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CommentedAt { get; set; }

        // FK
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }
    }
}
