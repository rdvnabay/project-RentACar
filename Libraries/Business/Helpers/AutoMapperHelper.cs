﻿using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandAddDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarAddDto>().ReverseMap();
            CreateMap<CarAddDto, CarImageAddDto>().ReverseMap();
            CreateMap<CarImage, CarImageDto>().ReverseMap();
            CreateMap<CarImage, CarImageAddDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Color, ColorAddDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
        }
    }
}
