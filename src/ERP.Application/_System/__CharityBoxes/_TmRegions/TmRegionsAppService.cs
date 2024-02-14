using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmRegions.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmRegions
{
    [AbpAuthorize]
    public class TmRegionsAppService : AsyncCrudAppService<TmRegions, TmRegionsDto, long, PagedTmRegionsResultRequestDto, CreateTmRegionsDto, TmRegionsEditDto>, ITmRegionsAppService
    {
        private readonly ITmRegionsManager _tmRegionsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        public TmRegionsAppService(IRepository<TmRegions, long> repository,
            ITmRegionsManager tmRegionsManager,
            IGetCounterRepository repoProcCounter) : base(repository)
        {
            _tmRegionsManager = tmRegionsManager;
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_TmRegions_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmRegions_Update;
            DeletePermissionName = PermissionNames.Pages_TmRegions_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmRegions;
        }

        public async override Task<PagedResultDto<TmRegionsDto>> GetAll(PagedTmRegionsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValues);


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.RegionName))
            {
                queryable = queryable.Where(q => q.RegionName.Contains(input.Params.RegionName));
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.RegionNumber))
            {
                queryable = queryable.Where(q => q.RegionNumber.Contains(input.Params.RegionNumber));
            }

            if (input.Params != null && input.Params.CityLkpId != null)
            {
                queryable = queryable.Where(q => q.CityLkpId == input.Params.CityLkpId);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<TmRegionsDto>());

            var PagedResultDto = new PagedResultDto<TmRegionsDto>()
            {
                Items = data2 as IReadOnlyList<TmRegionsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<TmRegionsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<TmRegionsDto>(current);

            return mapped;
        }

        public async override Task<TmRegionsDto> Create(CreateTmRegionsDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "TmRegions", TenantId = (int)AbpSession.TenantId, Lang = "EG-ar", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.RegionNumber = result?.FirstOrDefault()?.OutputStr ?? "0";

            return await base.Create(input);
        }

        public async override Task<TmRegionsDto> Update(TmRegionsEditDto input)
        {
            var Entity = await Repository.FirstOrDefaultAsync(input.Id);

            ObjectMapper.Map(input, Entity);

            return MapToEntityDto(await Repository.UpdateAsync(Entity));
        }

        public async Task<Select2PagedResult> GetTmRegionsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _tmRegionsManager.GetTmRegionsSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
