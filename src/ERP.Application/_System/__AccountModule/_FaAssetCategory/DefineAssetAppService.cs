using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._FaAssetCategory.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._FaAssetCategory
{
    [AbpAuthorize]
    public class DefineAssetAppService : AsyncCrudAppService<FaAssetCategory, FaAssetCategoryDto, long, FaAssetCategoryPagedDto, FaAssetCategoryCreateDto, FaAssetCategoryEditDto>,
        IDefineAssetAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetCounterRepository _repoProcCounter;

        public DefineAssetAppService(IRepository<FaAssetCategory, long> repository, IGetCounterRepository repoProcCounter, IGlCodeComDetailsManager glCodeComDetailsManager
              ) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_FaAssetCategory_Insert;
            UpdatePermissionName = PermissionNames.Pages_FaAssetCategory_Update;
            DeletePermissionName = PermissionNames.Pages_FaAssetCategory_Delete;
            GetAllPermissionName = PermissionNames.Pages_FaAssetCategory;
        }

        protected override IQueryable<FaAssetCategory> CreateFilteredQuery(FaAssetCategoryPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.GlCodeComDetailsAssetCostAccount, z => z.GlCodeComDetailsAssetClearingAccount, z => z.GlCodeComDetailsAccDeprenAccount, z => z.GlCodeComDetailsDeprenAccount);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AssetCategoryNumber))
                iqueryable = iqueryable.Where(z => z.AssetCategoryNumber.Contains(input.Params.AssetCategoryNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AssetCategoryNameAr))
                iqueryable = iqueryable.Where(z => z.AssetCategoryNameAr.Contains(input.Params.AssetCategoryNameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AssetCategoryNameEn))
                iqueryable = iqueryable.Where(z => z.AssetCategoryNameEn.Contains(input.Params.AssetCategoryNameEn));
            return iqueryable;
        }

        public async override Task<FaAssetCategoryDto> Create(FaAssetCategoryCreateDto input)
        {
            CheckCreatePermission();
            var counterInput = new GetCounterInputDto { CounterName = "FaAssetCategory", TenantId = (int)AbpSession.TenantId, Lang = input.Lang, year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.AssetCategoryNumber = result?.FirstOrDefault()?.OutputStr ?? "1";

            input.AssetCostAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);
            input.AssetClearingAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt1);
            input.AccDeprenAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt2);
            input.DeprenAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt3);

            var current = ObjectMapper.Map<FaAssetCategory>(input);

            await Repository.InsertAsync(current);

            return new FaAssetCategoryDto();
        }

        public async Task<FaAssetCategoryDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.GlCodeComDetailsAssetCostAccount, z => z.GlCodeComDetailsAssetClearingAccount, z => z.GlCodeComDetailsAccDeprenAccount, z => z.GlCodeComDetailsDeprenAccount)
                                          .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetailsAssetCostAccount,_app.Reqlanguage);
            (string ids1, string texts1) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetailsAssetClearingAccount, _app.Reqlanguage);
            (string ids2, string texts2) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetailsAccDeprenAccount, _app.Reqlanguage);
            (string ids3, string texts3) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetailsDeprenAccount, _app.Reqlanguage);

            var ReturnObj = ObjectMapper.Map<FaAssetCategoryDto>(current);

            ReturnObj.codeComUtilityIds = ids;
            ReturnObj.codeComUtilityTexts = texts;

            ReturnObj.codeComUtilityIds_alt1 = ids1;
            ReturnObj.codeComUtilityTexts_alt1 = texts1;

            ReturnObj.codeComUtilityIds_alt2 = ids2;
            ReturnObj.codeComUtilityTexts_alt2 = texts2;

            ReturnObj.codeComUtilityIds_alt3 = ids3;
            ReturnObj.codeComUtilityTexts_alt3 = texts3;

            return ReturnObj;
        }

        public async override Task<FaAssetCategoryDto> Update(FaAssetCategoryEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            var AssetCostAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);
            var AssetClearingAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt1);
            var AccDeprenAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt2);
            var DeprenAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt3);

            input.AssetCostAccountId = AssetCostAccountId == null ? input.AssetCostAccountId : AssetCostAccountId;
            input.AssetClearingAccountId = AssetClearingAccountId == null ? input.AssetClearingAccountId : AssetClearingAccountId;
            input.AccDeprenAccountId = AccDeprenAccountId == null ? input.AccDeprenAccountId : AccDeprenAccountId;
            input.DeprenAccountId = DeprenAccountId == null ? input.DeprenAccountId : DeprenAccountId;

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            return new FaAssetCategoryDto();
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            //return await _moduleManager.GetSelect2(searchTerm, pageSize, pageNumber, lang);
            var data = Repository.GetAll()
                 .Where(z => (string.IsNullOrEmpty(searchTerm) || z.AssetCategoryNameAr.Contains(searchTerm) || z.AssetCategoryNameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel
                        {
                            id = z.Id,
                            text = (lang == "ar-EG") ? z.AssetCategoryNameAr : z.AssetCategoryNameEn,
                            altText = z.NoMonthsDepreciation.HasValue ? z.NoMonthsDepreciation.Value.ToString() : ""
                        })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

    }
}
