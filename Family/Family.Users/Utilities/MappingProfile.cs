using AutoMapper;
using Family.Db.Entities;
using Family.Web.Models.GenderModels;
using Family.Web.Models.UserModels;

namespace Family.Users.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadModel>();
            CreateMap<UserWriteModel, User>();

            CreateMap<Gender, GenderReadModel>();
            CreateMap<GenderWriteModel, Gender>();
        }
    }
}
