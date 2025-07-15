using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class CheckLevelLog
    {
        [Key]
        public int Log_Id { get; set; }

        [ForeignKey("Seller")]
        public int Sel_User_Id { get; set; }
        public Seller Seller { get; set; }

        public decimal Totla_Selles_This_Month { get; set; }

        [ForeignKey("Level")]
        public int LevelId { get; set; }
        public required Level Level { get; set; }

        public bool Can_Upgrade { get; set; }

        public DateTime Checked_At { get; set; }

        public DateTime Updated_At { get; set; }

        [ForeignKey("Admin")]
        public int Admin_User_Id { get; set; }
        public Admin Admin { get; set; }
    }
}
