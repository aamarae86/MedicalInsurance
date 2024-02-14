using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Dto;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System.__AidModule._ScCampainsDetail.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCampains
{
    [AbpAuthorize]
    public class ScCampainsDetailDeliverAppService : ERPAppServiceBase, IScCampainsDetailDeliverAppService
    {
        private readonly IRepository<ScCampainsDetail, long> _repoScCampainsDetail;
        private readonly IScCampainsDetailDeliverRepository _scCampainsDetailDeliverRepository;

        public ScCampainsDetailDeliverAppService(IRepository<ScCampains, long> repository,
            IRepository<ScCampainsDetail, long> repoScCampainsDetail,
            IScCampainsDetailDeliverRepository scCampainsDetailDeliverRepository
            )
        {
            _repoScCampainsDetail = repoScCampainsDetail;
            _scCampainsDetailDeliverRepository = scCampainsDetailDeliverRepository;
        }

        public async Task<PagedResultDto<MasterDetailDto>> GetAllForDetials(PagedMasterDetailResultRequestDto input)
        {
            var dtFrom = !string.IsNullOrEmpty(input.Params.FromScCampainDate) ? DateTimeController.ConvertToDateTime(input.Params.FromScCampainDate) : DateTime.MinValue;
            var dtTo = !string.IsNullOrEmpty(input.Params.FromScCampainDate) ? DateTimeController.ConvertToDateTime(input.Params.ToScCampainDate) : DateTime.MinValue;

            var queryable = _repoScCampainsDetail.GetAllIncluding(w => w.ScCampains, w => w.PortalFndUsers, w => w.ScCampainsAid, w => w.FndLookupValues).Where(z => z.StatusLkpId != 145 &&
                            (input.Params == null || input.Params.portalFndUsersId1 == null || input.Params.portalFndUsersId1 == 0 || z.PortalFndUsersId == input.Params.portalFndUsersId1) &&
                            (input.Params == null || input.Params.portalFndUsersId2 == null || input.Params.portalFndUsersId1 == 0 || z.PortalFndUsersId == input.Params.portalFndUsersId2) &&
                            (input.Params == null || input.Params.CampainName == null || z.CampainId == Convert.ToInt64(input.Params.CampainName)) &&
                            (input.Params == null || input.Params.campainAidId == null || input.Params.campainAidId == 0 || z.CampainAidId == input.Params.campainAidId) &&
                            (input.Params == null || input.Params.FromScCampainDate == null || (z.ScCampains.ScCampainDate >= dtFrom)) &&
                            (input.Params == null || input.Params.ToScCampainDate == null || (z.ScCampains.ScCampainDate <= dtTo)) &&
                            (input.Params == null || input.Params.statusLkpId == null || input.Params.statusLkpId == 0 || z.StatusLkpId == input.Params.statusLkpId));

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<MasterDetailDto>());

            var PagedResultDto = new PagedResultDto<MasterDetailDto>()
            {
                Items = data2 as IReadOnlyList<MasterDetailDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<PostOutput> scCampainsDetailDeliver(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _scCampainsDetailDeliverRepository.Execute(postDto, "ScCampainsDetailDeliver");

            return result.FirstOrDefault();
        }
    }
}
