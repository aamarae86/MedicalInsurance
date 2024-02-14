using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._CrmProjects;
using ERP._System.__CRM._CrmProjects.Dto;
using ERP._System._Projects;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._Counters._CrmProjects
{
    [AbpAuthorize]
 


        public class CrmProjectsAppService : AttachBaseAsyncCrudAppService<CrmProjects, CrmProjectsDto, long, CrmProjectsPagedDto, CrmProjectsCreateDto, CrmProjectsEditDto, AttachAuditedEntity>, ICrmProjectsAppService
        {
        private readonly IEntityCounterManager _entityCounterManager;

        public CrmProjectsAppService(IRepository<CrmProjects, long> repository, IEntityCounterManager entityCounterManager, IConfiguration config, IImageConfig imageConfig) : base(repository, config)
            {
            _entityCounterManager = entityCounterManager;

            CreatePermissionName = PermissionNames.Pages_CrmProjects_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmProjects_Update;
            DeletePermissionName = PermissionNames.Pages_CrmProjects_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmProjects;
                PreFileName = "Project_";
                ServiceFolder = "CrmProjects";
            }

        protected override IQueryable<CrmProjects> CreateFilteredQuery(CrmProjectsPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ProjectName))
                iqueryable = iqueryable.Where(z => z.ProjectNameAr.Contains(input.Params.ProjectName)||
                                                   z.ProjectNameEn.Contains(input.Params.ProjectName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ProjectDate))
                iqueryable = iqueryable.Where(z => z.ProjectDate==DateTimeController.ConvertToDateTime(input.Params.ProjectDate));


            return iqueryable;
        }

        public async override Task<CrmProjectsDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAll().FirstOrDefaultAsync(s=>s.Id==input.Id);

            return ObjectMapper.Map<CrmProjectsDto>(current);
        }

        public async override Task<CrmProjectsDto> Create(CrmProjectsCreateDto input)
        {
            CheckCreatePermission();
            return await base.Create(input);
        }
    }
}
