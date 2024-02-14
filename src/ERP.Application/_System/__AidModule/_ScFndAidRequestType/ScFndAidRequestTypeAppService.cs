using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScFndAidRequestType.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScFndAidRequestType
{
    [AbpAuthorize]
    public class ScFndAidRequestTypeAppService : AsyncCrudAppService<ScFndAidRequestType, ScFndAidRequestTypeDto, long, PagedScFndAidRequestTypeResultRequestDto, CreateScFndAidRequestTypeDto, ScFndAidRequestTypeEditDto>,
        IScFndAidRequestTypeAppService
    {
        private readonly IScFndAidRequestTypeManager _scFndAidRequestTypeManager;

        public ScFndAidRequestTypeAppService(IRepository<ScFndAidRequestType, long> repository,
            IScFndAidRequestTypeManager scFndAidRequestTypeManager) : base(repository)
        {
            _scFndAidRequestTypeManager = scFndAidRequestTypeManager;

            CreatePermissionName = PermissionNames.Pages_ScFndAidRequestType_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScFndAidRequestType_Update;
            DeletePermissionName = PermissionNames.Pages_ScFndAidRequestType_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScFndAidRequestType;
        }

        public async override Task<ScFndAidRequestTypeDto> Create(CreateScFndAidRequestTypeDto input)
        {
            CheckCreatePermission();

            bool checkExistBefore = await Repository.GetAll().Where(z => z.AidRequestTypeLkpId == input.AidRequestTypeLkpId)
                                                    .AnyAsync();

            if (checkExistBefore) return new ScFndAidRequestTypeDto { ExistBefore = true };
            else return await base.Create(input);
        }

        public async override Task<ScFndAidRequestTypeDto> Update(ScFndAidRequestTypeEditDto input)
        {
            CheckUpdatePermission();

            bool checkExistBefore = await Repository.GetAll().Where(z => z.AidRequestTypeLkpId == input.AidRequestTypeLkpId && z.Id != input.Id)
                                                    .AnyAsync();

            if (checkExistBefore) return new ScFndAidRequestTypeDto { ExistBefore = true };
            else return await base.Update(input);
        }

        public async override Task<PagedResultDto<ScFndAidRequestTypeDto>> GetAll(PagedScFndAidRequestTypeResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValues);

            if (input.Params != null && input.Params.AidRequestTypeLkpId != null)
                queryable = queryable.Where(q => q.AidRequestTypeLkpId == input.Params.AidRequestTypeLkpId);

            if (input.Params != null && !input.Params.IsAll)
            {
                if (input.Params != null) queryable = queryable.Where(q => q.IsElectronics == input.Params.IsElectronics);

                if (input.Params != null) queryable = queryable.Where(q => q.IsMaintenance == input.Params.IsMaintenance);
            }

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScFndAidRequestTypeDto>());

            var PagedResultDto = new PagedResultDto<ScFndAidRequestTypeDto>()
            {
                Items = data2 as IReadOnlyList<ScFndAidRequestTypeDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ScFndAidRequestTypeDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues).Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map(current, new ScFndAidRequestTypeDto());
        }

        public async Task<Select2PagedResult> GetAidRequestTypeLkpForTenant(int tenantId, string lang)
        {
            var result = await Repository.GetAllIncluding(c => c.FndLookupValues)
                .Where(a => a.TenantId == tenantId)
                .OrderBy(q => q.Id).Select(z =>
                    new Select2OptionModel
                    {
                        id = z.Id,
                        text = lang == "ar-EG" ? z.FndLookupValues.NameAr : z.FndLookupValues.NameEn
                    }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = result.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetAidRequestTypeLkp(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _scFndAidRequestTypeManager.GetAidRequestTypeLkp(searchTerm, pageSize, pageNumber, lang);
    }
}
