using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__PmPropertiesModule._PmOtherPaymentTypes.Dto;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes
{
    [AbpAuthorize]
    public class PmOtherPaymentTypesAppService : AsyncCrudAppService<PmOtherPaymentTypes, PmOtherPaymentTypesDto, long, PagedPmOtherPaymentTypesResultRequestDto, CreatePmOtherPaymentTypesDto, PmOtherPaymentTypesEditDto>,
        IPmOtherPaymentTypesAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IPmOtherPaymentTypesManager _pmOtherPaymentTypesManager;

        public PmOtherPaymentTypesAppService(IRepository<PmOtherPaymentTypes, long> repository,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IPmOtherPaymentTypesManager pmOtherPaymentTypesManager) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _pmOtherPaymentTypesManager = pmOtherPaymentTypesManager;

            CreatePermissionName = PermissionNames.Pages_PmOtherPaymentTypes_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmOtherPaymentTypes_Update;
            DeletePermissionName = PermissionNames.Pages_PmOtherPaymentTypes_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmOtherPaymentTypes;
        }

        public async override Task<PagedResultDto<PmOtherPaymentTypesDto>> GetAll(PagedPmOtherPaymentTypesResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.GlCodeComDetails);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PaymentTypeName))
                queryable = queryable.Where(q => q.PaymentTypeName.Contains(input.Params.PaymentTypeName));

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            queryable = queryable.OrderByDescending(x => x.CreationTime);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<PmOtherPaymentTypesDto>());
            var counter = 0;

            foreach (var item in data)
            {
                (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails,_app.Reqlanguage);
                data2[counter].codeComUtilityIds = ids;
                data2[counter].codeComUtilityTexts = texts;
                ++counter;
            }

            var PagedResultDto = new PagedResultDto<PmOtherPaymentTypesDto>()
            {
                Items = data2 as IReadOnlyList<PmOtherPaymentTypesDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<PmOtherPaymentTypesDto> Create(CreatePmOtherPaymentTypesDto input)
        {
            CheckCreatePermission();

            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            input.AccountId = currentComCodeId.Value;

            var currentDetail = ObjectMapper.Map<PmOtherPaymentTypes>(input);

            await Repository.InsertAsync(currentDetail);

            return new PmOtherPaymentTypesDto();
        }

        public async Task<PmOtherPaymentTypesDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(vv => vv.GlCodeComDetails).Where(z => z.Id == input.Id)
           .FirstOrDefaultAsync();

            var ReturnObj = ObjectMapper.Map<PmOtherPaymentTypesDto>(current);

            (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetails, _app.Reqlanguage);

            ReturnObj.codeComUtilityIds = ids;
            ReturnObj.codeComUtilityTexts = texts;

            return ReturnObj;
        }

        public async override Task<PmOtherPaymentTypesDto> Update(PmOtherPaymentTypesEditDto input)
        {
            CheckUpdatePermission();

            var currentGeJeLine = await Repository.GetAsync((long)input.Id);
            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            var mappedDto = ObjectMapper.Map(currentGeJeLine, new PmOtherPaymentTypesDto());

            mappedDto.AccountId = (long)currentComCodeId;
            mappedDto.PaymentTypeName = input.PaymentTypeName;
            mappedDto.IsActive = input.IsActive;

            var mappedEntity = ObjectMapper.Map(mappedDto, currentGeJeLine);

            _ = await Repository.UpdateAsync(mappedEntity);

            return new PmOtherPaymentTypesDto();
        }

        public async Task<Select2PagedResult> GetPmOtherPaymentTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmOtherPaymentTypesManager.GetPmOtherPaymentTypesSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
