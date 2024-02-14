using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._PyPayrollTypes.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyPayrollTypes
{
    [AbpAuthorize]
    public class PyPayrollTypesAppService : AsyncCrudAppService<PyPayrollTypes, PyPayrollTypesDto, long, PyPayrollTypesPagedDto, PyPayrollTypesCreateDto, PyPayrollTypesEditDto>, IPyPayrollTypesAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPyPayrollTypesManager _pyPayrollTypesManager;

        public PyPayrollTypesAppService(IRepository<PyPayrollTypes, long> repository,
            IGetCounterRepository getCounterRepository,
            IPyPayrollTypesManager pyPayrollTypesManager) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _pyPayrollTypesManager = pyPayrollTypesManager;

            CreatePermissionName = PermissionNames.Pages_PyPayrollTypes_Insert;
            UpdatePermissionName = PermissionNames.Pages_PyPayrollTypes_Update;
            DeletePermissionName = PermissionNames.Pages_PyPayrollTypes_Delete;
            GetAllPermissionName = PermissionNames.Pages_PyPayrollTypes;
        }

        protected override IQueryable<PyPayrollTypes> CreateFilteredQuery(PyPayrollTypesPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PayrollTypeNumber))
                iqueryable = iqueryable.Where(z => z.PayrollTypeNumber.Contains(input.Params.PayrollTypeNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PyPayrollTypeName))
                iqueryable = iqueryable.Where(z => z.PyPayrollTypeName.Contains(input.Params.PyPayrollTypeName));

            return iqueryable;
        }

        public async override Task<PyPayrollTypesDto> Create(PyPayrollTypesCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "PyPayrollTypes", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.PayrollTypeNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            return await base.Create(input);
        }

        public async Task<Select2PagedResult> GetPyPayrollTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pyPayrollTypesManager.GetPyPayrollTypesSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
