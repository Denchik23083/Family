using AutoMapper;
using Family.Db.Entities.Users;
using Family.Db.Entities.Web;
using Family.Web.Models.ChildModels;
using Family.Web.Models.GenderModels;
using Family.Web.Models.GenusModels;
using Family.Web.Models.ParentModels;
using Family.Web.Models.UserModels;

namespace Family.Web.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadModel>();
            CreateMap<UserWriteModel, User>();

            CreateMap<Gender, GenderReadModel>();
            CreateMap<GenderWriteModel, Gender>();

            CreateMap<Genus, GenusReadNameModel>();
            CreateMap<Genus, GenusReadModel>();
            CreateMap<GenusWriteNameModel, Genus>();
            CreateMap<GenusWriteModel, Genus>();

            CreateMap<Parent, ParentReadModel>();
            CreateMap<ParentWriteModel, Parent>();

            CreateMap<Child, ChildReadModel>();
            CreateMap<ChildWriteModel, Child>();
        }
    }
}
