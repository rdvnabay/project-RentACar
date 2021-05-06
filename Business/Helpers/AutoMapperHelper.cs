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
            CreateMap<Car, CarForListDto>().ReverseMap();
            CreateMap<User, UserForListDto>().ReverseMap();
        }
    }
}
