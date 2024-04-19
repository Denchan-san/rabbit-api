using AutoMapper;
using Rabbit_API.Models.Dto.Threads;

namespace Rabbit_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {

            CreateMap<Models.Thread, ThreadDTO>().ReverseMap();
            CreateMap<Models.Thread, CreateThreadDTO>().ReverseMap();
            CreateMap<Models.Thread, UpdateThreadDTO>().ReverseMap();
        }
    }
}
