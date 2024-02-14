using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmEngineers
{
    [AbpAuthorize]
    public class FmEngineersAppService : AsyncCrudAppService<FmEngineers, FmEngineersDto, long, FmEngineersPagedDto, FmEngineersCreateDto, FmEngineersEditDto>, IFmEngineersAppService
    {
        private readonly IEntityCounterManager _entityCounterManager;

        public FmEngineersAppService(IRepository<FmEngineers, long> repository, IEntityCounterManager entityCounterManager) : base(repository)
        {
            _entityCounterManager = entityCounterManager;

            CreatePermissionName = PermissionNames.Pages_FmEngineers_Insert;
            UpdatePermissionName = PermissionNames.Pages_FmEngineers_Update;
            DeletePermissionName = PermissionNames.Pages_FmEngineers_Delete;
            GetAllPermissionName = PermissionNames.Pages_FmEngineers;
        }

        protected override IQueryable<FmEngineers> CreateFilteredQuery(FmEngineersPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.EngineerNumber))
                iqueryable = iqueryable.Where(z => z.EngineerNumber.Contains(input.Params.EngineerNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.EngineerName))
                iqueryable = iqueryable.Where(z => z.EngineerName.Contains(input.Params.EngineerName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Mobile1))
                iqueryable = iqueryable.Where(z => z.Mobile1.Contains(input.Params.Mobile1));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            return iqueryable;
        }

        public async override Task<FmEngineersDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.HrPersons, x => x.HrPersons.FndGenderLkp, x => x.HrPersons.FndNationalityLkp).Where(x => x.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<FmEngineersDto>(current);
        }

        public async override Task<FmEngineersDto> Create(FmEngineersCreateDto input)
        {
            CheckCreatePermission();

            input.EngineerNumber = await _entityCounterManager.GetEntityNumber("FmEngineers", (int)AbpSession.TenantId);

            return await base.Create(input);
        }
    }
}
