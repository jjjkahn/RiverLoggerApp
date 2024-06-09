using AutoMapper;
using RiverLoggerApi.Models;
using RiverLoggerApi.Repository.DbModels;
namespace RiverLoggerApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LoginInputModel, UserDbo>().ReverseMap();
            CreateMap<RegisterInputModel, UserDbo>().ReverseMap();
            CreateMap<EventInputModel, EventDbo>().ReverseMap();
            CreateMap<UserEventInputModel, UserEventDbo>().ReverseMap();
        }
    }
}
