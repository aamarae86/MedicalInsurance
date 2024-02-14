using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using ERP.Authorization;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.Helpers.Core;
using ERP.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ERP.Roles
{
    [AbpAuthorize]
    public class RoleAppService : AsyncCrudAppService<Role, RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IRepository<AbpKpiRole, long> _repoAbpKpiRole;
        public RoleAppService(IRepository<Role> repository
            , RoleManager roleManager
            , UserManager userManager
            , IRepository<AbpKpiRole, long> repoAbpKpiRole) : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _repoAbpKpiRole = repoAbpKpiRole;

            CreatePermissionName = PermissionNames.Pages_Roles_Insert;
            UpdatePermissionName = PermissionNames.Pages_Roles_Update;
            DeletePermissionName = PermissionNames.Pages_Roles_Delete;
            GetAllPermissionName = PermissionNames.Pages_Roles;
        }

        public override async Task<RoleDto> Create(CreateRoleDto input)
        {
            CheckCreatePermission();

            if (input.GrantedPermissions == null)
            {
                input.GrantedPermissions = new List<string>();
            }

            var role = ObjectMapper.Map<Role>(input);
            role.SetNormalizedName();

            CheckErrors(await _roleManager.CreateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        public async Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input)
        {
            var roles = await _roleManager
                .Roles
                .WhereIf(
                    !input.Permission.IsNullOrWhiteSpace(),
                    r => r.Permissions.Any(rp => rp.Name == input.Permission && rp.IsGranted)
                )
                .ToListAsync();

            return new ListResultDto<RoleListDto>(ObjectMapper.Map<List<RoleListDto>>(roles));
        }

        public override async Task<RoleDto> Update(RoleDto input)
        {
            CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            input.CreatorUserId = role.CreatorUserId;

            ObjectMapper.Map(input, role);

            CheckErrors(await _roleManager.UpdateAsync(role));

            if (input.GrantedPermissions != null)
            {
                var grantedPermissions = PermissionManager
            .GetAllPermissions()
            .Where(p => input.GrantedPermissions.Contains(p.Name))
            .ToList();

                await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            }
            return MapToEntityDto(role);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            CheckDeletePermission();

            var role = await _roleManager.FindByIdAsync(input.Id.ToString());
            var users = await _userManager.GetUsersInRoleAsync(role.NormalizedName);

            foreach (var user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.NormalizedName));
            }

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionDto>(
                ObjectMapper.Map<List<PermissionDto>>(permissions)
                .OrderBy(p => p.DisplayName).ToList()
            ));
        }

        protected override IQueryable<Role> CreateFilteredQuery(PagedRoleResultRequestDto input)
        {
            if (input == null | input.Params == null)
                return Repository.GetAllIncluding(x => x.Permissions);
            return Repository.GetAllIncluding(x => x.Permissions)
                .WhereIf(!input.Params.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Params.Name))
                .WhereIf(!input.Params.Description.IsNullOrWhiteSpace(), x => x.Description.Contains(input.Params.Description)/* || x.Name.Contains(input.Keyword) || x.EmailAddress.Contains(input.Keyword)*/)
                .WhereIf(!input.Params.DisplayName.IsNullOrWhiteSpace(), x => x.DisplayName.Contains(input.Params.DisplayName));
        }

        protected override async Task<Role> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAllIncluding(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedRoleResultRequestDto input)
        {
            return query.OrderBy(r => r.DisplayName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input)
        {
            var permissions = PermissionManager.GetAllPermissions();
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            var grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
            var roleEditDto = ObjectMapper.Map<RoleEditDto>(role);

            return new GetRoleForEditOutput
            {
                Role = roleEditDto,
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
            };
        }

        public async Task<RoleDto> AddUsersToRole(RoleUsersInsertDto input)
        {
            CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);

            foreach (var userInRole in input.UserIds)
            {
                var user = await _userManager.GetUserByIdAsync(userInRole);
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    CheckErrors(await _userManager.AddToRoleAsync(user, role.Name));
                }
            }

            return MapToEntityDto(role);
        }

        public async Task<RoleUsersInsertDto> GetUsersForRole(int id)
        {
            CheckUpdatePermission();

            RoleUsersInsertDto roleUsersInsertDto = new RoleUsersInsertDto()
            {
                RoleId = id,
                UserIds = new List<int>(),
                UsersInRole = new List<UserInRoleDto>()
            };

            var role = await _roleManager.GetRoleByIdAsync(id);
            var users = await _userManager.GetUsersInRoleAsync(role.Name);

            foreach (var user in users)
            {
                roleUsersInsertDto.UserIds.Add((int)user.Id); //new UserInRoleDto() { Id = user.Id, Name = user.UserName });
                roleUsersInsertDto.UsersInRole.Add(new UserInRoleDto() { Id = user.Id, Name = user.UserName });
            }

            return roleUsersInsertDto;
        }

        public async Task DeleteUserFromRole(int UserId, int RoleId)
        {
            CheckDeletePermission();

            var role = await _roleManager.GetRoleByIdAsync(RoleId);
            var user = await _userManager.GetUserByIdAsync(UserId);

            CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.Name));
        }

        public async Task<RoleDto> UpdatePermissions(UpdateRolePermissionsDto input)
        {
            CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            //ObjectMapper.Map(input, role);

            //CheckErrors(await _roleManager.UpdateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            return MapToEntityDto(role);
        }

        public List<AbpKpiRoleDto> GetAllRoleKpis(long roleId , long? perantId)
        {
            var kpis = _repoAbpKpiRole.GetAll().Include(x=>x.FndKpisLkp).Where(x=>x.RoleId == roleId &&(x.FndKpisLkp.ParentId == perantId || perantId == null)).ToList();
            var kpisMapped = ObjectMapper.Map<List<AbpKpiRoleDto>>(kpis);
            return kpisMapped;
            
        }


        public async  Task UpdateRoleKpis(AbpKpiRoleCreateDto input)
        {
            await CROD_RoleKpis(input.RoleKpi);
        }

        private async Task CROD_RoleKpis(ICollection<AbpKpiRoleDto> kpiRoleDtos)
        {
            if (kpiRoleDtos?.Count > 0)
            {
                foreach (var item in kpiRoleDtos)
                {
                    if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var invoiceSettlementDrs = ObjectMapper.Map<AbpKpiRole>(item);

                        _ = await _repoAbpKpiRole.InsertAsync(invoiceSettlementDrs);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoAbpKpiRole.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

    }
}
