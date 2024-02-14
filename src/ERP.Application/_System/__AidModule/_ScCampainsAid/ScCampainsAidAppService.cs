using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System._ScCampainsAid.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ScCampainsAid
{
    public class ScCampainsAidAppService : AsyncCrudAppService<ScCampainsAid, ScCampainsAidDto, long, PagedScCampainsAidResultRequestDto, CreateScCampainsAidDto, ScCampainsAidEditDto>, IScCampainsAidAppService
    {
        private readonly IScCampainsAidManager _scCampainsAidManager;

        public ScCampainsAidAppService(IRepository<ScCampainsAid, long> repository,
            IScCampainsAidManager scCampainsAidManager) : base(repository)
        {
            _scCampainsAidManager = scCampainsAidManager;

            CreatePermissionName = PermissionNames.Pages_ScCampainsAid_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScCampainsAid_Update;
            DeletePermissionName = PermissionNames.Pages_ScCampainsAid_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScCampainsAid;
        }

        public async Task<ScCampainsAidDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ScCampainsAidDto>(current);

            return mapped;
        }

        public async override Task<PagedResultDto<ScCampainsAidDto>> GetAll(PagedScCampainsAidResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValues);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AidName))
            {
                queryable = queryable.Where(q => q.AidName.Contains(input.Params.AidName));
            }
            if (input.Params != null && input.Params.AidAmount != null && input.Params.AidAmount != 0)
            {
                queryable = queryable.Where(q => q.AidAmount == input.Params.AidAmount);
            }
            if (input.Params != null && input.Params.CampainsAidCategoryLkpId != null && input.Params.CampainsAidCategoryLkpId != 0)
            {
                queryable = queryable.Where(q => q.CampainsAidCategoryLkpId == input.Params.CampainsAidCategoryLkpId);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScCampainsAidDto>());
            var PagedResultDto = new PagedResultDto<ScCampainsAidDto>()
            {
                Items = data2 as IReadOnlyList<ScCampainsAidDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<Select2PagedResult> GetScCampainsAidSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
               => await _scCampainsAidManager.GetScCampainsAidSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
