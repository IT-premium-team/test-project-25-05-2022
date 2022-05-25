using AutoMapper;

using Data.Dto;
using Data.Models;

namespace Data.Mappers
{
    public class UserDtoMappingProfile : Profile
    {
        public UserDtoMappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<User, UserDto>();
        }
    }
     
}
