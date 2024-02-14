using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._GlAccHeaders.Dto;
using ERP._System._GlAccHeaders.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._GlAccHeaders
{
    [AbpAuthorize]
    public class GlAccHeadersAppService : AsyncCrudAppService<GlAccHeaders, GlAccHeadersDto, long, PagedGlAccHeadersResultRequestDto, CreateGlAccHeadersDto, GlAccHeadersEditDto>,
         IGlAccHeadersAppService
    {
        private readonly IGlAccHeadersManager _glAccHeadersManager;

        public GlAccHeadersAppService(IRepository<GlAccHeaders, long> repository, IGlAccHeadersManager glAccHeadersManager)
            : base(repository)
        {
            _glAccHeadersManager = glAccHeadersManager;

            CreatePermissionName = PermissionNames.Pages_GlAccHeaders_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlAccHeaders_Update;
            DeletePermissionName = PermissionNames.Pages_GlAccHeaders_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlAccHeaders;
        }

        public override async Task<GlAccHeadersDto> Create(CreateGlAccHeadersDto input)
        {
            CheckCreatePermission();

            var current = GlAccHeaders.Create(input.NameAr, input.NameEn, input.AttributeLkpId, input.IsHide, input.ShowOrder, input.ParentId);

            await Repository.InsertAsync(current);

            return new GlAccHeadersDto();
        }

        public Task<ListResultDto<GlAccHeadersListDto>> GetGlAccHeadersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GlAccHeadersDetailDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, x => x.Parent,s=>s.GlAccDetails)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<GlAccHeadersDetailDto>(current);

            return mapped;
        }

        public async override Task<PagedResultDto<GlAccHeadersDto>> GetAll(PagedGlAccHeadersResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAll()
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr1Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr2Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr3Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr4Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr5Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr6Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr7Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr8Collection)
                .Include(s => s.GlAccDetails).ThenInclude(s => s.GlAccDetailsAttr9Collection)
                .Where(s => true);

            if (!string.IsNullOrEmpty(input.Params.NameAr))
            {
                queryable = queryable.Where(q => q.NameAr.Contains(input.Params.NameAr));
            }
            if (!string.IsNullOrEmpty(input.Params.NameEn))
            {
                queryable = queryable.Where(q => q.NameEn.Contains(input.Params.NameEn));
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<GlAccHeadersDto>());

            var PagedResultDto = new PagedResultDto<GlAccHeadersDto>()
            {
                Items = data2 as IReadOnlyList<GlAccHeadersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<Select2PagedResult> GetGlAccHeadersSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string trigger, long? updatedId)
            => await _glAccHeadersManager.GetGlAccHeadersSelect2(searchTerm, pageSize, pageNumber, lang, trigger, updatedId);

    }
}
