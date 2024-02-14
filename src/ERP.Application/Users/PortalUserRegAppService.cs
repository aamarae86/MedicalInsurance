using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using ERP._System._Portal._PortalFndUsers;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Helpers.Core;
using ERP.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Users
{
    public class PortalUserRegAppService : AsyncCrudAppService<User, UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserEditDto>, IPortalUserRegAppService
    {
        private readonly UserManager _userManager;
        private readonly UserAppService _userAppService;
        private readonly IPortalUnifiedUsersManager _portalUnifiedUsersManager;
        private readonly IRepository<PortalUser, long> _repoPortalUser;

        public PortalUserRegAppService(IRepository<User, long> repository,
            IRepository<PortalUser, long> repoPortalUser, IPortalUnifiedUsersManager portalUnifiedUsersManager,
            UserManager userManager, UserAppService userAppService) : base(repository)
        {
            _userManager = userManager;
            _userAppService = userAppService;
            _repoPortalUser = repoPortalUser;
            _portalUnifiedUsersManager = portalUnifiedUsersManager;

            CreatePermissionName = PermissionNames.Pages_PortalUserReg_Insert;
            UpdatePermissionName = PermissionNames.Pages_PortalUserReg_Update;
            DeletePermissionName = PermissionNames.Pages_PortalUserReg_Delete;
            GetAllPermissionName = PermissionNames.Pages_PortalUserReg;
        }

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            var currentPortalUser = await _repoPortalUser.GetAsync(input.PortalUserId);

            if (currentPortalUser == null) throw new EntityNotFoundException(typeof(PortalUser), input.PortalUserId);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;
            user.IsPortalUser = true;
            user.Name = currentPortalUser.Name;
            user.Surname = currentPortalUser.Name;
            user.TenantId = null;
                
            using (CurrentUnitOfWork.SetTenantId(null))
            {
                await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

                await _userManager.CreateAsync(user, input.Password);

                if (!await _userAppService.GenerateResetLinkAndSendMail(user)) throw new Exception();

                return MapToEntityDto(user);
            }
        }

        public override async Task<UserDto> Update(UserEditDto input)
        {
            CheckUpdatePermission();

            CurrentUnitOfWork.SetTenantId(null);

            var user = await _userManager.GetUserByIdAsync(input.Id);

            input.UserName = user.UserName;
            input.Name = user.Name;
            input.Surname = user.Surname;

            MapToEntity(input, user);

            await _userManager.UpdateAsync(user);

            return null;
        }

        public async Task<Select2PagedResult> GetPortalUnfiedUsersForRegisterToPortalSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _portalUnifiedUsersManager.GetPortalUnfiedUsersForRegisterToPortalSelect2(searchTerm, pageSize, pageNumber, lang);

        protected override IQueryable<User> CreateFilteredQuery(PagedUserResultRequestDto input)
        {
            CurrentUnitOfWork.SetTenantId(null);

            var query = Repository.GetAll().Where(z => z.IsPortalUser);

            if (input == null | input.Params == null) return query;

            return query
                .Where(x => input.Params.UserName.IsNullOrWhiteSpace() || x.UserName.Contains(input.Params.UserName))
                .Where(x => input.Params.Name.IsNullOrWhiteSpace() || x.Name.Contains(input.Params.Name))
                .Where(x => input.Params.Surname.IsNullOrWhiteSpace() || x.Surname.Contains(input.Params.Surname))
                .Where(x => input.Params.FullName.IsNullOrWhiteSpace() || x.FullName.Contains(input.Params.FullName))
                .Where(x => input.Params.EmailAddress.IsNullOrWhiteSpace() || x.EmailAddress.Contains(input.Params.EmailAddress))
                .Where(x => !input.Params.IsActive.HasValue || x.IsActive == input.Params.IsActive);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            CurrentUnitOfWork.SetTenantId(null);

            var user = await Repository.GetAllIncluding().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) throw new EntityNotFoundException(typeof(User), id);

            return user;
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedUserResultRequestDto input) => query.OrderBy(r => r.UserName);
    }
}
