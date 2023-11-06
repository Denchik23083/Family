using AutoMapper;
using Family.Db.Entities;
using Family.Web.Models.ChildModels;
using Family.Web.Models.GenusModels;
using Family.Web.Models.ParentModels;

namespace Family.Web.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genus, GenusReadNameModel>();
            CreateMap<Genus, GenusReadModel>();
            CreateMap<GenusWriteModel, Genus>();

            CreateMap<Parent, ParentReadModel>();
            CreateMap<ParentWriteModel, Parent>();

            CreateMap<Child, ChildReadModel>();
            CreateMap<ChildWriteModel, Child>();
        }
    }
}
