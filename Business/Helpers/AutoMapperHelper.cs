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
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<Car, CarListDto>()
                //Todo: One to many relationship with automapper
                .ForMember(dest => dest.BrandName, opt =>
                {
                    opt.MapFrom(src => src.Brand.Name);
                });
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
        }
    }
}
