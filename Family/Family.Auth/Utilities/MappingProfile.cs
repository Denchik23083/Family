using AutoMapper;
using Family.Auth.Models;
using Family.Db.Entities;

namespace Family.Auth.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModel, User>();

            CreateMap<LoginModel, User>();
        }
    }
}
