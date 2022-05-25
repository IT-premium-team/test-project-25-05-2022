using AutoMapper;

using Data.Dto;
using Data.Models;

namespace Data.Mappers
{
    public class PostDtoMappingProfile : Profile
    {
        public PostDtoMappingProfile()
        {
            CreateMap<PostDto, Post>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
     
}
