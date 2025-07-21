using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface IDiscountCodeRepository
    {
        public IEnumerable<DiscountCode> GetAll();

        public DiscountCode GetById(int id);

        public DiscountCode GetByCode(string code);

        public Task Create(DiscountCode discountCode);

        public void Update(DiscountCode discountCode);

        public void Delete(int id);

        public Task<bool> CheckExist(string code);

        public Task Save();
    }
}
