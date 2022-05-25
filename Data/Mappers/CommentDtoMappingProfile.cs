using AutoMapper;

using Data.Dto;
using Data.Models;

namespace Data.Mappers
{
    public class CommentDtoMappingProfile : Profile
    {
        public CommentDtoMappingProfile()
        {
            CreateMap<CommentDto, Comment>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
     
}
