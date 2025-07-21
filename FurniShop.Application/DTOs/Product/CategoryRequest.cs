using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.Product
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(255)]
        public string CategoryName { get; set; } = null!;
    }
}
