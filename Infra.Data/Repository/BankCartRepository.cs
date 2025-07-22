using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class BankCartRepository : IBankCartRepository
    {
        private readonly FurniShopDbContext _ctx;
        public BankCartRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<BankCartInformation?> GetCart(int CartId)
        {
            return await _ctx.BankCarts.FindAsync(CartId);
        }

        public async Task<BankCartInformation?> GetCartById(int UserId)
        {
            return await _ctx.BankCarts.FindAsync(UserId);
        }

        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task Create(BankCartInformation bankCart)
        {
            await _ctx.BankCarts.AddAsync(bankCart);
            await Save();
        }

        public async Task<bool> CheckHaveBankCart(int UserId)
        {
            return await _ctx.BankCarts.AnyAsync(c => c.UserId == UserId);
        }

        public async Task<bool> CheckExistCart(int id)
        {
            return await _ctx.BankCarts.AnyAsync(c => c.CartId == id);
        }

        public async Task Update(BankCartInformation bankCart)
        {
            _ctx.BankCarts.Update(bankCart);
            await Save();
        }

        public async Task Delete(BankCartInformation cart)
        {
            _ctx.BankCarts.Remove(cart);
            await Save();
        }
    }
}
