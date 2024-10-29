using AutoMapper;
using Rabbit_API.Models;
using Rabbit_API.Models.Dto.Commentary;
using Rabbit_API.Models.Dto.Posts;
using Rabbit_API.Models.Dto.Threads;
using Rabbit_API.Models.Dto.Users;

namespace Rabbit_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Models.Thread, ThreadDTO>().ReverseMap();
            CreateMap<Models.Thread, CreateThreadDTO>().ReverseMap();
            CreateMap<Models.Thread, UpdateThreadDTO>().ReverseMap();

            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Post, CreatePostDTO>().ReverseMap();
            CreateMap<Post, UpdatePostDTO>().ReverseMap();

            CreateMap<Commentary, CommentaryDTO>().ReverseMap();
            CreateMap<Commentary, CreateCommentaryDTO>().ReverseMap();
            CreateMap<Commentary, UpdateCommentaryDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar));

        }
    }
}
