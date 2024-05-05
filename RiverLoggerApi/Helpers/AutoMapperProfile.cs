using AutoMapper;
using RiverLoggerApi.Models;
using RiverLoggerApi.Repository.DbModels;
namespace RiverLoggerApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDbo>();
            CreateMap<UserDbo, User>();
        }
    }
}
