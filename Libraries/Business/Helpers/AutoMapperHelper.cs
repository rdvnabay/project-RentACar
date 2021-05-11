using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<Car, CarDto>()
                //Todo: One to many relationship with automapper
                .ForMember(dest => dest.BrandName, opt =>
                {
                    opt.MapFrom(src => src.Brand.Name);
                });
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
        }
    }
}
