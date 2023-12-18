using AutoMapper;
using Family.Auth.Models;
using Family.Db.Entities.Auth;
using Family.Db.Entities.Users;

namespace Family.Auth.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterWriteModel, User>();

            CreateMap<LoginWriteModel, User>();

            CreateMap<RefreshTokenWriteModel, RefreshToken>();

            CreateMap<Gender, GenderReadModel>();
        }
    }
}
