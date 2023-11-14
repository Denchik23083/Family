using AutoMapper;
using Family.Db.Entities;
using Family.Users.Models;

namespace Family.Users.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadModel>();

            CreateMap<Gender, GenderReadModel>();

            CreateMap<GenderReadModel, Gender>();
        }
    }
}
