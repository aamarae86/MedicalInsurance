using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScFndAidRequestType.Dto;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto;
using ERP._System._FndLookupValues;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting
{
    [AbpAuthorize]
    public class ScFndProtalAttachmentSettingAppService : AsyncCrudAppService<ScFndProtalAttachmentSetting, ScFndProtalAttachmentSettingDto, long, PagedScFndProtalAttachmentSettingResultRequestDto, CreateScFndProtalAttachmentSettingDto, ScFndProtalAttachmentSettingEditDto>,
        IScFndProtalAttachmentSettingAppService
    {
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;

        public ScFndProtalAttachmentSettingAppService(IRepository<ScFndProtalAttachmentSetting, long> repository,
            IRepository<FndLookupValues, long> repoFndLookupValues) : base(repository)
        {
            _repoFndLookupValues = repoFndLookupValues;
        }

        public async Task<ScFndProtalAttachmentSettingDto> GetDetailAsync(EntityDto<long> input)
        {
            var data = await Repository.GetAllIncluding(z => z.ScFndAidRequestType)
                         .Where(z => z.Id == input.Id)
                         .FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map(data, new ScFndProtalAttachmentSettingDto());

            var currentLkp = await _repoFndLookupValues.GetAsync(mapped.ScFndAidRequestType.AidRequestTypeLkpId);

            mapped.ScFndAidRequestType = new ScFndAidRequestTypeDto
            {
                NameAr = currentLkp.NameAr,
                NameEn = currentLkp.NameEn
            };

            return mapped;
        }

        public async override Task<PagedResultDto<ScFndProtalAttachmentSettingDto>> GetAll(PagedScFndProtalAttachmentSettingResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.ScFndAidRequestType);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AttachmentNameAr))
                queryable = queryable.Where(q => q.AttachmentNameAr.Contains(input.Params.AttachmentNameAr));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AttachmentNameEn))
                queryable = queryable.Where(q => q.AttachmentNameEn.Contains(input.Params.AttachmentNameEn));


            if (input.Params != null && input.Params.RequestTypeId != null)
                queryable = queryable.Where(q => q.RequestTypeId == input.Params.RequestTypeId);

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScFndProtalAttachmentSettingDto>());

            foreach (var item in data2)
            {
                var currentLkp = await _repoFndLookupValues.GetAsync(item.ScFndAidRequestType.AidRequestTypeLkpId);

                item.ScFndAidRequestType = new ScFndAidRequestTypeDto
                {
                    NameAr = currentLkp.NameAr,
                    NameEn = currentLkp.NameEn
                };
            }

            var PagedResultDto = new PagedResultDto<ScFndProtalAttachmentSettingDto>()
            {
                Items = data2 as IReadOnlyList<ScFndProtalAttachmentSettingDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ListResultDto<ScFndProtalAttachmentSettingDto>> GetProtalAttachmentSettingForAidRequestTypeLkp(long RequestTypeId)
        {
            var data = await Repository.GetAllListAsync(s => s.IsActive && s.RequestTypeId == RequestTypeId);
            var result = data.OrderBy(q => q.IsRequired).ToList();

            return new ListResultDto<ScFndProtalAttachmentSettingDto>(ObjectMapper.Map<List<ScFndProtalAttachmentSettingDto>>(result));
        }

        public async Task<List<ScFndProtalAttachmentSettingDto>> GetAttachmentSettingByAidType(long aidTypeId)
        {
            var data = await Repository.GetAll().Where(z => z.RequestTypeId == aidTypeId && z.IsActive).ToListAsync();

            return ObjectMapper.Map(data, new List<ScFndProtalAttachmentSettingDto>());
        }
    }
}
