using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndCollectors.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._FndCollectors
{
    [AbpAuthorize]
    public class FndCollectorsAppService : AsyncCrudAppService<FndCollectors, FndCollectorsDto, long, PagedFndCollectorsResultRequestDto, CreateFndCollectorsDto, FndCollectorsEditDto>, IFndCollectorsAppService
    {
        private readonly IFndCollectorsManager _fndCollectorsManager;
        private readonly IGetCounterRepository _repoProcCounter;

        public FndCollectorsAppService(IRepository<FndCollectors, long> repository,
            IFndCollectorsManager fndCollectorsManager,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _fndCollectorsManager = fndCollectorsManager;
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_FndCollectors_Insert;
            UpdatePermissionName = PermissionNames.Pages_FndCollectors_Update;
            DeletePermissionName = PermissionNames.Pages_FndCollectors_Delete;
            GetAllPermissionName = PermissionNames.Pages_FndCollectors;
        }

        public async override Task<FndCollectorsDto> Create(CreateFndCollectorsDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "FndCollectors", TenantId = (int)AbpSession.TenantId, Lang = input.Lang, year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.CollectorNumber = Convert.ToInt32(result?.FirstOrDefault()?.OutputStr ?? "1");

            return await base.Create(input);
        }

        public async Task<bool> GetExistCollectorNameArAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.CollectorNameAr.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistCollectorNameEnAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.CollectorNameEn.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async override Task<PagedResultDto<FndCollectorsDto>> GetAll(PagedFndCollectorsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAll();

            if (!string.IsNullOrEmpty(input.Params.CollectorNameAr))
            {
                queryable = queryable.Where(q => q.CollectorNameAr.Contains(input.Params.CollectorNameAr));
            }

            if (!string.IsNullOrEmpty(input.Params.CollectorNameEn))
            {
                queryable = queryable.Where(q => q.CollectorNameEn.Contains(input.Params.CollectorNameEn));
            }

            if (input.Params.CollectorNumber != null && input.Params.CollectorNumber != 0)
            {
                queryable = queryable.Where(q => q.CollectorNumber == input.Params.CollectorNumber);
            }

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<FndCollectorsDto>());

            var PagedResultDto = new PagedResultDto<FndCollectorsDto>()
            {
                Items = data2 as IReadOnlyList<FndCollectorsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<Select2PagedResult> GetFndCollectorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndCollectorsManager.GetFndCollectorsSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
