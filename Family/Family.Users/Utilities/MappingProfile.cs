using AutoMapper;
using Family.Core.Utilities;
using Family.Db.Entities;
using Family.Users.Models.AdminModels;
using Family.Users.Models.PasswordModels;
using Family.Users.Models.UserModels;
using Family.Web.Models.ChildModels;
using Family.Web.Models.GenderModels;
using Family.Web.Models.GenusModels;
using Family.Web.Models.ParentModels;
using Family.Web.Models.UserModels;

namespace Family.Users.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadNameModel>();
            CreateMap<User, UserReadModel>();
            CreateMap<UserWriteModel, User>();
            CreateMap<User, AdminReadNameModel>();

            CreateMap<Gender, GenderReadModel>();

            CreateMap<Genus, GenusReadModel>();

            CreateMap<Parent, ParentReadModel>();

            CreateMap<Child, ChildReadModel>();

            CreateMap<PasswordWriteModel, Password>();
        }
    }
}
