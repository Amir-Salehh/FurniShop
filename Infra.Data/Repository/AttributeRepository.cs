using FurniShop.Domain.Interfaces;
using FurniShop.Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly FurniShopDbContext _ctx;
        public AttributeRepository(FurniShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CheckExist(string name)
        {
            return await _ctx.Attributes.AnyAsync(a => a.Name == name);
        }

        public async Task Create(Attributes attribute)
        {
           await _ctx.Attributes.AddAsync(attribute);
           await Save();
        }

        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
