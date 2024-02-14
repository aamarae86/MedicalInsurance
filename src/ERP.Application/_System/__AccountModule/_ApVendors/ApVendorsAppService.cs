using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System._ApVendors;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApVendors
{
    [AbpAuthorize]
    public class ApVendorsAppService : AsyncCrudAppService<ApVendors, ApVendorsDto, long, PagedApVendorsResultRequestDto, ApVendorsCreateDto, ApVendorsEditDto>,
        IApVendorsAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IApVendorsManager _apVendorsManager;

        public ApVendorsAppService(IApVendorsManager apVendorsManager,
            IRepository<ApVendors, long> repository, IEntityCounterManager entityCounterManager)  : base(repository)
        {
            _entityCounterManager = entityCounterManager;
            _apVendorsManager = apVendorsManager;

            CreatePermissionName = PermissionNames.Pages_ApVendors_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApVendors_Update;
            DeletePermissionName = PermissionNames.Pages_ApVendors_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApVendors;
        }

        protected override IQueryable<ApVendors> CreateFilteredQuery(PagedApVendorsResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.FndVendorCategoryLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VendorNumber))
                iqueryable = iqueryable.Where(z => z.VendorNumber.Contains(input.Params.VendorNumber));


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VendorNameAr))
                iqueryable = iqueryable.Where(z => z.VendorNameAr.Contains(input.Params.VendorNameAr));


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VendorNameEn))
                iqueryable = iqueryable.Where(z => z.VendorNameEn.Contains(input.Params.VendorNameEn));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            return iqueryable;
        }

        public async Task<ApVendorsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndStatusLkp, x => x.FndVendorCategoryLkp)
                                          .Where(z => z.Id == input.Id)
                                          .FirstOrDefaultAsync();

            return ObjectMapper.Map<ApVendorsDto>(current);
        }

        public async override Task<ApVendorsDto> Create(ApVendorsCreateDto input)
        {
            CheckCreatePermission();

            input.VendorNumber = await _entityCounterManager.GetEntityNumber("ApVendors", (int)AbpSession.TenantId);

            return await base.Create(input);
        }

        public async Task<bool> GetExistVendorNameArAsync(string input, string Id)
        {
            var current = await Repository.GetAll().Where(x => x.VendorNameAr.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistVendorNameEnAsync(string input, string Id)
        {
            var current = await Repository.GetAll().Where(x => x.VendorNameEn.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<Select2PagedResult> GetVendorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _apVendorsManager.GetVendorsSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
