using AutoMapper;
using Domain.Entities;
using Service.DTOs.User;
using Service.Services.DTOs.Account;
using Service.Services.DTOs.Location;
using Service.Services.DTOs.Order;
using Service.Services.DTOs.SubLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AppUser , RegisterDto >().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationCreateDto>().ReverseMap();
            CreateMap<Location ,LocationEditDto > ().ReverseMap();
            CreateMap<SubLocation, SubLocationDto>().ReverseMap();
            CreateMap<SubLocation, SubLocationCreateDto>().ReverseMap();
            CreateMap<SubLocation, SubLocationEditDto>().ReverseMap();
            CreateMap<AppUser, CurrentUserInfoDto>().ReverseMap();
            CreateMap<Driver, RegisterDriverDto>().ReverseMap();
            CreateMap<AppUser, RegisterDriverDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
