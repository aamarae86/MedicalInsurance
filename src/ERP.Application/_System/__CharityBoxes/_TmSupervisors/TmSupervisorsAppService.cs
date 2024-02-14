using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmSupervisors.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmSupervisors
{
    [AbpAuthorize]
    public class TmSupervisorsAppService : AsyncCrudAppService<TmSupervisors, TmSupervisorsDto, long, PagedTmSupervisorsResultRequestDto, CreateTmSupervisorsDto, TmSupervisorsEditDto>, ITmSupervisorsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ITmSupervisorsManager _tmSupervisorsManager;

        public TmSupervisorsAppService(IRepository<TmSupervisors, long> repository,
                 IGetCounterRepository repoProcCounter,
                 ITmSupervisorsManager tmSupervisorsManager) : base(repository)
        {
            _repoProcCounter = repoProcCounter;
            _tmSupervisorsManager = tmSupervisorsManager;

            CreatePermissionName = PermissionNames.Pages_TmSupervisors_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmSupervisors_Update;
            DeletePermissionName = PermissionNames.Pages_TmSupervisors_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmSupervisors;
        }

        public async override Task<PagedResultDto<TmSupervisorsDto>> GetAll(PagedTmSupervisorsResultRequestDto input)
        {
            CheckUpdatePermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValues);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.SupervisorNumber))
            {
                queryable = queryable.Where(q => q.SupervisorNumber.Contains(input.Params.SupervisorNumber));
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.SupervisorName))
            {
                queryable = queryable.Where(q => q.SupervisorName.Contains(input.Params.SupervisorName));
            }

            if (input.Params != null && input.Params.StatusLkpId != null)
            {
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<TmSupervisorsDto>());

            var PagedResultDto = new PagedResultDto<TmSupervisorsDto>()
            {
                Items = data2 as IReadOnlyList<TmSupervisorsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<TmSupervisorsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<TmSupervisorsDto>(current);

            return mapped;
        }

        public async override Task<TmSupervisorsDto> Create(CreateTmSupervisorsDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "TmSupervisors", TenantId = (int)AbpSession.TenantId, Lang = "EG-ar", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.SupervisorNumber = result?.FirstOrDefault()?.OutputStr ?? "0";

            return await base.Create(input);
        }

        public async Task<Select2PagedResult> GetTmSupervisorsBoxesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _tmSupervisorsManager.GetTmSupervisorsBoxesSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
