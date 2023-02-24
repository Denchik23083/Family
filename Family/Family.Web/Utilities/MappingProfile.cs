using AutoMapper;
using Family.Db.Entities;
using Family.Web.Models.ChildrenModels;
using Family.Web.Models.ParentsModels;

namespace Family.Web.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Parent, ParentsReadModel>();
            CreateMap<ParentsWriteModel, Parent>();

            CreateMap<Child, ChildrenReadModel>();
            CreateMap<ChildrenWriteModel, Child>();
        }
    }
}
