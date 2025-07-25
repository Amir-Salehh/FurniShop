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
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly FurniShopDbContext _ctx;
        public DiscountCodeRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(DiscountCode discountCode)
        {
            await _ctx.DiscountCodes.AddAsync(discountCode);
            await Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiscountCode> GetAll()
        {
            return _ctx.DiscountCodes
                .Include(p => p.Products)
                .AsEnumerable();

        }

        public async Task<DiscountCode> GetByCode(string code)
        {
            var DiscountCode = await _ctx.DiscountCodes.FindAsync(code);
            return DiscountCode!;
        }

        public async Task<DiscountCode> GetById(int id)
        {
            var DiscountCode = await _ctx.DiscountCodes.FindAsync(id);
            return DiscountCode!;
        }

        public Task Update(DiscountCode discountCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckExist(string code)
        {
            return await _ctx.DiscountCodes.AnyAsync(d => d.Code == code);
        }
        public async Task<bool> CheckExist(int id)
        {
            return await _ctx.DiscountCodes.AnyAsync(d => d.DiscountCodeId == id);
        }

        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
