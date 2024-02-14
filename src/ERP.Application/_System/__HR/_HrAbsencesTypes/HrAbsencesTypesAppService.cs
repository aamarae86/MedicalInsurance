using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrAbsencesTypes.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrAbsencesTypes
{
    [AbpAuthorize]
    public class HrAbsencesTypesAppService : AsyncCrudAppService<HrVacationsTypes, HrVacationsTypesDto, long, HrVacationsTypesPagedDto, HrVacationsTypesCreateDto, HrVacationsTypesEditDto>,
        IHrAbsencesTypesAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        public HrAbsencesTypesAppService(IRepository<HrVacationsTypes, long> repository,
                                         IGetCounterRepository repoProcCounter) : base(repository)
        {
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_HrVacationsTypes_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrVacationsTypes_Update;
            DeletePermissionName = PermissionNames.Pages_HrVacationsTypes_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrVacationsTypes;
        }

        protected override IQueryable<HrVacationsTypes> CreateFilteredQuery(HrVacationsTypesPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VacationsTypeName))
                iqueryable = iqueryable.Where(z => z.VacationsTypeName.Contains(input.Params.VacationsTypeName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VacationsTypeNumber))
                iqueryable = iqueryable.Where(z => z.VacationsTypeNumber == input.Params.VacationsTypeNumber);

            return iqueryable;
        }

        public async override Task<HrVacationsTypesDto> Create(HrVacationsTypesCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "HrAbsencesTypes", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.VacationsTypeNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            return await base.Create(input);
        }
    }
}
