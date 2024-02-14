using AutoMapper;
using ERP.Authorization.Users;
using ERP.Helpers.Core;

namespace ERP.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(x => x.SubEndDate, source => source.MapFrom( o => o.SubEndDate.HasValue ?  o.SubEndDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
        }
    }
}
