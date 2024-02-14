using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrOrganizations.Dto;
using ERP._System._GlAccounts.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrOrganizations
{
    [AbpAuthorize]
    public class HrOrganizationsAppService : AsyncCrudAppService<HrOrganizations, HrOrganizationsDto, long, HrOrganizationsPagedDto, HrOrganizationsCreateDto, HrOrganizationsEditDto>,
        IHrOrganizationsAppService
    {
        private readonly IHrOrganizationsManager _hrOrganizationsManager;

        public HrOrganizationsAppService(IRepository<HrOrganizations, long> repository,
            IHrOrganizationsManager hrOrganizationsManager) : base(repository)
        {
            _hrOrganizationsManager = hrOrganizationsManager;

            CreatePermissionName = PermissionNames.Pages_HrOrganizations_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrOrganizations_Update;
            DeletePermissionName = PermissionNames.Pages_HrOrganizations_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrOrganizations;
        }

        protected override IQueryable<HrOrganizations> CreateFilteredQuery(HrOrganizationsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndOrganizationTypeLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OrganizationName))
                iqueryable = iqueryable.Where(z => z.OrganizationName.Contains(input.Params.OrganizationName));

            if (input.Params != null && input.Params.OrganizationTypeLkpId != null)
                iqueryable = iqueryable.Where(z => z.OrganizationTypeLkpId == input.Params.OrganizationTypeLkpId);

            return iqueryable;
        }

        public async Task<List<CustomTreeReturn>> GetHRTree(long id, string lang = "ar-EG")
        {
            var data = await Repository.GetAll().Where(x => x.Id != id).ToListAsync();

            var result = data.OrderBy(q => q.Id)
                             .Select(z => new CustomTreeReturn { id = z.Id.ToString(), parent = z.ParentId != null ? z.ParentId.ToString() : "#", text = $"{z.OrganizationName}" })
                             .ToList();
            return result;
        }

        public async Task<HrOrganizationsDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<HrOrganizationsDto>(await Repository.GetAllIncluding(z => z.Parent, x => x.FndOrganizationTypeLkp).Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<bool> GetExistOrganizationNameAsync(string input, long Id)
            => await Repository.GetAll().Where(x => x.OrganizationName.ToLower() == input.ToLower() && x.Id != Id).AnyAsync();

        public async Task<Select2PagedResult> GetHrOrganizationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrOrganizationsManager.GetHrOrganizationsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetHrOrganizationsWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrOrganizationsManager.GetHrOrganizationsWithParentSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
