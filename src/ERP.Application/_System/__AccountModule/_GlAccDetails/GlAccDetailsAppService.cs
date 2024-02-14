using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._GlAccDetails.Dto;
using ERP._System._GlAccDetails.Dto;
using ERP._System._GlAccHeaders.Dto;
using ERP._System._GlJeLines;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._GlAccDetails
{
    [AbpAuthorize]
    public class GlAccDetailsAppService : AsyncCrudAppService<GlAccDetails, GlAccDetailsDto, long, PagedGlAccDetailsResultRequestDto, CreateGlAccDetailsDto, GlAccDetailsEditDto>,
        IGlAccDetailsAppService
    {
        private readonly IGlAccDetailsManager _glAccDetailsManager;
        private readonly IRepository<GlJeLines, long> _repoGlJeLines;
        public GlAccDetailsAppService(IRepository<GlAccDetails, long> repository,
             IRepository<GlJeLines, long> repoGlJeLines,
            IGlAccDetailsManager glAccDetailsManager)
            : base(repository)
        {
            _glAccDetailsManager = glAccDetailsManager;
            _repoGlJeLines = repoGlJeLines;
            CreatePermissionName = PermissionNames.Pages_GlAccDetails_Insert;
            UpdatePermissionName = PermissionNames.Pages_GlAccDetails_Update;
            DeletePermissionName = PermissionNames.Pages_GlAccDetails_Delete;
            GetAllPermissionName = PermissionNames.Pages_GlAccDetails;
        }

        public async Task<List<GlAccHeadersDto>> DrawGlAccController()
        {
            var data = await _glAccDetailsManager.DrawGlAccController();

            return data.MapTo<List<GlAccHeadersDto>>();
        }

        public async Task<GlAccDetailsDetailDto> GetDetailAsync(EntityDto<long> input)
        {
            var data = await Repository
                .GetAllIncluding(z => z.GlAccHeader, x => x.GlAccDetail)
                         .Where(z => z.Id == input.Id)
                         .FirstOrDefaultAsync();


            var mapped = ObjectMapper.Map(data, new GlAccDetailsDetailDto());

            return mapped;
        }

        public async override Task<GlAccDetailsDto> Create(CreateGlAccDetailsDto input)
        {
            CheckCreatePermission();

            var codeExist = await _glAccDetailsManager.CodeExist(null, input.Code, input.GlAccHeaderId, input.ParentId);

            if (codeExist.Item2) return new GlAccDetailsDto { CodeExistBefore = true };

            var nameExist = await _glAccDetailsManager.NameExist(null, input.NameAr, input.NameEn);

            if (nameExist.Item2) return new GlAccDetailsDto { NameExistBefore = true };

            return await base.Create(input);
        }

        public async override Task<GlAccDetailsDto> Update(GlAccDetailsEditDto input)
        {
            CheckUpdatePermission();

            var codeExist = await _glAccDetailsManager.CodeExist(input.Id, input.Code, input.GlAccHeaderId, input.UpdateParentId);

            if (codeExist.Item2) return new GlAccDetailsDto { CodeExistBefore = true };

            var nameExist = await _glAccDetailsManager.NameExist(input.Id, input.NameAr, input.NameEn);

            if (nameExist.Item2) return new GlAccDetailsDto { NameExistBefore = true };

            return await base.Update(input);
        }

        public async override Task<PagedResultDto<GlAccDetailsDto>> GetAll(PagedGlAccDetailsResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.GlAccHeader

            , x => x.GlAccDetailsAttr1Collection
                , x => x.GlAccDetailsAttr2Collection
                , x => x.GlAccDetailsAttr3Collection
                , x => x.GlAccDetailsAttr4Collection
                , x => x.GlAccDetailsAttr5Collection
                , x => x.GlAccDetailsAttr6Collection
                , x => x.GlAccDetailsAttr7Collection
                , x => x.GlAccDetailsAttr8Collection
                , x => x.GlAccDetailsAttr9Collection
            );

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.NameAr))
                queryable = queryable.Where(q => q.NameAr.Contains(input.Params.NameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.NameEn))
                queryable = queryable.Where(q => q.NameEn.Contains(input.Params.NameEn));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Code))
                queryable = queryable.Where(q => q.Code.Contains(input.Params.Code));

            if (input.Params != null && input.Params.GlAccHeaderId != null)
                queryable = queryable.Where(q => q.GlAccHeaderId == input.Params.GlAccHeaderId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<GlAccDetailsDto>());

            var PagedResultDto = new PagedResultDto<GlAccDetailsDto>()
            {
                Items = data2 as IReadOnlyList<GlAccDetailsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<bool> NameExist(long? id, string nameAr, string nameEn)
        {
            var check = await _glAccDetailsManager.NameExist(id, nameAr, nameEn);

            return check.Item2;
        }

        public async Task<bool> CodeExist(long? id, string code, long GlAccHeaderId, long? parentId)
        {
            var check = await _glAccDetailsManager.CodeExist(id, code, GlAccHeaderId, parentId);

            return check.Item2;
        }

        public async Task<DefaulGlAccDetailsInfo> GetDefaultGlAccDetails(string lang = "ar-EG")
        {
            var (ids, texts, isDefArr) = await _glAccDetailsManager.GetDefaultGlAccDetails(lang);

            return new DefaulGlAccDetailsInfo { ids = ids, texts = texts, isDefArr = isDefArr };
        }

        public async Task<Select2PagedResult> GetGlAccDetailsSelect2(long glheaderId, long? parentId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glAccDetailsManager.GlAccDetailsSelect2(glheaderId, parentId, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetGlAccHeaderDetailsSelect2(long glheaderId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glAccDetailsManager.GetGlAccHeaderDetailsSelect2(glheaderId, searchTerm, pageSize, pageNumber, lang);
    }
}
