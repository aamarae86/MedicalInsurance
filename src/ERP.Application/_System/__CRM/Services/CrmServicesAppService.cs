
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._CrmServices;
using ERP._System.__CRM._CrmServices.Dto;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Services;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._Counters._CrmServices
{
    [AbpAuthorize]
        public class CrmServicesAppService : AttachBaseAsyncCrudAppService<CrmServices, CrmServicesDto, long, CrmServicesPagedDto, CrmServicesCreateDto, CrmServicesEditDto, AttachAuditedEntity>, ICrmServicesAppService
        {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly ICrmServicesManager _repoICrmServicesManager;

        public CrmServicesAppService(IRepository<CrmServices, long> repository,
            IEntityCounterManager entityCounterManager,
            IConfiguration config,
            IImageConfig imageConfig,
            ICrmServicesManager repoICrmServicesManager) : base(repository, config)
            {
            _entityCounterManager = entityCounterManager;
            _repoICrmServicesManager = repoICrmServicesManager;

            CreatePermissionName = PermissionNames.Pages_CrmServices_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmServices_Update;
            DeletePermissionName = PermissionNames.Pages_CrmServices_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmServices;
                PreFileName = "Service_";
                ServiceFolder = "CrmServices";
            }

        protected override IQueryable<CrmServices> CreateFilteredQuery(CrmServicesPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ServiceName))
                iqueryable = iqueryable.Where(z => z.ServiceNameAr.Contains(input.Params.ServiceName) ||
                                                   z.ServiceNameEn.Contains(input.Params.ServiceName));
 
            return iqueryable;
        }

        public async override Task<CrmServicesDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAll().FirstOrDefaultAsync(s=>s.Id==input.Id);

            return ObjectMapper.Map<CrmServicesDto>(current);
        }

        public async override Task<CrmServicesDto> Create(CrmServicesCreateDto input)
        {
            CheckCreatePermission();
            return await base.Create(input);
        }

        public async Task<Select2PagedResult> GetCrmServicesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _repoICrmServicesManager.GetCrmServicesSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
