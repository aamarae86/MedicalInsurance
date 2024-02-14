using System.Linq;
using AutoMapper;
using Abp.Authorization;
using Abp.Authorization.Roles;
using ERP.Authorization.Roles;
using ERP.Core.Helpers.Extensions;

namespace ERP.Roles.Dto
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            // Role and permission
            CreateMap<Permission, string>().ConvertUsing(r => r.Name);
            CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

            CreateMap<CreateRoleDto, Role>();

            CreateMap<RoleDto, Role>();
            CreateMap<RoleEditDto, Role>();

            CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
                opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

            CreateMap<Role, RoleEditDto>().ForMember(x => x.GrantedPermissions,
                opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

            CreateMap<Role, RoleListDto>();
            CreateMap<Permission, FlatPermissionDto>();

            CreateMap<AbpKpiRole, AbpKpiRoleDto>()
            .ForMember(dest => dest.Kpi, source => source.MapFrom(o => o.FndKpisLkp.GetLookupValue()))
            .ForMember(dest => dest.FndKpisLkp, source => source.Ignore());

            CreateMap<AbpKpiRoleDto, AbpKpiRole>();
        }
    }
}
