using AutoMapper;
using FurniShop.Application.DTOs.Product;
using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Profiles
{
    public class CategoryMappingProfile :Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryResponseDto>();
        }
    }
}
