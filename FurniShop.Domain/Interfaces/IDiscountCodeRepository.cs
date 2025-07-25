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

        public Task<DiscountCode> GetById(int id);

        public Task<DiscountCode> GetByCode(string code);

        public Task Create(DiscountCode discountCode);

        public Task Update(DiscountCode discountCode);

        public void Delete(int id);

        public Task<bool> CheckExist(string code);
        public Task<bool> CheckExist(int id);

        public Task Save();
    }
}
