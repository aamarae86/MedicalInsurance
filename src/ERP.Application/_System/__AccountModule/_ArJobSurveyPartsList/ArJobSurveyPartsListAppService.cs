using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArJobSurveyPartsList;
using ERP._System.__CharityBoxes._ArJobSurveyPartsList.Dto;
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

namespace ERP._System.__CharityBoxes._ArJobSurveyPartsList
{
    [AbpAuthorize]
    public class ArJobSurveyPartsListAppService : AsyncCrudAppService<ArJobSurveyPartsList, ArJobSurveyPartsListDto, long, PagedArJobSurveyPartsListResultRequestDto, CreateArJobSurveyPartsListDto, ArJobSurveyPartsListEditDto>, IArJobSurveyPartsListAppService
    {
       // private readonly IArJobSurveyPartsListManager _ArJobSurveyPartsListManager;
        private readonly IGetCounterRepository _repoProcCounter;
        public ArJobSurveyPartsListAppService(IRepository<ArJobSurveyPartsList, long> repository,
          //  IArJobSurveyPartsListManager ArJobSurveyPartsListManager,
            IGetCounterRepository repoProcCounter) : base(repository)
        {
           // _ArJobSurveyPartsListManager = ArJobSurveyPartsListManager;
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_ArJobSurveyPartsList_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArJobSurveyPartsList_Update;
            DeletePermissionName = PermissionNames.Pages_ArJobSurveyPartsList_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArJobSurveyPartsList;
        }

        public async override Task<PagedResultDto<ArJobSurveyPartsListDto>> GetAll(PagedArJobSurveyPartsListResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.PartsCategoryLkp);


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PartsName))
            {
                queryable = queryable.Where(q => q.PartsName.Contains(input.Params.PartsName));
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PartsNumber))
            {
                queryable = queryable.Where(q => q.PartsNumber.Contains(input.Params.PartsNumber));
            }

            if (input.Params != null && input.Params.PartsCategoryLkpId != null)
            {
                queryable = queryable.Where(q => q.PartsCategoryLkpId == input.Params.PartsCategoryLkpId);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArJobSurveyPartsListDto>());

            var PagedResultDto = new PagedResultDto<ArJobSurveyPartsListDto>()
            {
                Items = data2 as IReadOnlyList<ArJobSurveyPartsListDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ArJobSurveyPartsListDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.PartsCategoryLkp)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ArJobSurveyPartsListDto>(current);

            return mapped;
        }

        public async override Task<ArJobSurveyPartsListDto> Create(CreateArJobSurveyPartsListDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "ArJobSurveyPartsList", TenantId = (int)AbpSession.TenantId, Lang = "EG-ar", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.PartsNumber = result?.FirstOrDefault()?.OutputStr ?? "0";

            return await base.Create(input);
        }

        public async override Task<ArJobSurveyPartsListDto> Update(ArJobSurveyPartsListEditDto input)
        {
            var Entity = await Repository.FirstOrDefaultAsync(input.Id);

            ObjectMapper.Map(input, Entity);

            return MapToEntityDto(await Repository.UpdateAsync(Entity));
        }

        public async Task<Select2PagedResult> GetArJobSurveyPartsListSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await Repository.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (z.PartsName.Contains(searchTerm) || z.PartsNumber.Contains(searchTerm)))/*.Include(z => z.FndLookupValues)*/
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.PartsName} - {z.PartsNumber}" }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<Select2PagedResult> GetArJobSurveyPartsListByPerentIdSelect2(long? parentId, string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await Repository.GetAll()
                .Where(z => (
                 string.IsNullOrEmpty(searchTerm) || (z.PartsName.Contains(searchTerm) || z.PartsNumber.Contains(searchTerm))) && z.PartsCategoryLkpId == parentId)/*.Include(z => z.FndLookupValues)*/
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.PartsName} - {z.PartsNumber}" }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
