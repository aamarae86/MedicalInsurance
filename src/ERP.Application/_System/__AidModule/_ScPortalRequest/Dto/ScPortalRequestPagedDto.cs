using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequest.Dto
{
    public class ScPortalRequestPagedDto : PagedResultRequestDto, ISortModel
    {
        public ScPortalRequestSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
