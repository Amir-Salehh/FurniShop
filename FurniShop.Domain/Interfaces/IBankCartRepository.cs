using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Interfaces
{
    public interface IBankCartRepository
    {
        public Task<BankCartInformation?> GetCart(int UserId);

        public Task<BankCartInformation?> GetCartById(int UserId);

        public Task Save();

        public Task<bool> CheckHaveBankCart(int UserId);

        public Task Create(BankCartInformation bankCartInformation);

        public Task<bool> CheckExistCart(int id);

        public Task Update(BankCartInformation bankCart);

        public Task Delete(BankCartInformation cart);

    }
}
