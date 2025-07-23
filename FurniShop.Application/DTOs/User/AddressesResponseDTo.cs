using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.User
{
    public class AddressesResponseDTo
    {
        public string address { get; set; } = null!;

        public string PostalCode { get; set; } = null!;
    }
}
