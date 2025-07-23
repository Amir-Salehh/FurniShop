using AutoMapper;
using FurniShop.Application.DTOs.User;
using FurniShop.Domain.Models;

namespace FurniShop.Application.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponseDTo>();
            CreateMap<Address, AddressesResponseDTo>();
            CreateMap<BankCartInformation, BankCartRequest>();

        }
    }
}
