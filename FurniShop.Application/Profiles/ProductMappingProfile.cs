using AutoMapper;
using FurniShop.Application.DTOs.Product;
using FurniShop.Domain.Models;

namespace FurniShop.Application.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
