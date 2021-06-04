using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.Car;
using Entities.Dtos.Brand;
using Entities.Dtos.CarImage;
using Entities.Dtos.Color;

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
            CreateMap<Car, CarDetailDto>().ReverseMap();
            CreateMap<CarAddDto, CarImageAddDto>().ReverseMap();
            CreateMap<CarImage, CarImageDto>().ReverseMap();
            CreateMap<CarImage, CarImageAddDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Color, ColorAddDto>().ReverseMap();
            CreateMap<Customer, CustomerAddDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<Rental, RentalAddDto>().ReverseMap();
            CreateMap<Rental, RentalListDto>().ReverseMap();
        }
    }
}
