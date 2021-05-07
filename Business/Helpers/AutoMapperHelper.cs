using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq;

namespace Business.Helpers
{
    public class AutoMapperHelper:Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<Car, CarForListDto>()
                //Todo: One to many relationship with automapper
                .ForMember(dest => dest.BrandName, opt =>
                {
                    opt.MapFrom(src => src.Brand.Name);
                });
            CreateMap<User, UserForListDto>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Color, ColorListDto>().ReverseMap();
        }
    }
}
