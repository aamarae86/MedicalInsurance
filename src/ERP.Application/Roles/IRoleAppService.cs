using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP.Roles.Dto;
using Microsoft.AspNetCore.Identity;

namespace ERP.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);

        Task<RoleDto> AddUsersToRole(RoleUsersInsertDto input);

        Task<RoleUsersInsertDto> GetUsersForRole(int id);

        Task DeleteUserFromRole(int UserId, int RoleId);

        Task<RoleDto> UpdatePermissions(UpdateRolePermissionsDto input);
        List<AbpKpiRoleDto> GetAllRoleKpis(long roleId, long? perantId);
        Task UpdateRoleKpis(AbpKpiRoleCreateDto kpiRoleDtos);
    }
}
