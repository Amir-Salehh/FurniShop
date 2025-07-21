using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface IAttributeRepository
    {
        public Task<bool> CheckExist(string name);

        public Task Create(Attributes attribute);

        public Task Save();
    }

}
