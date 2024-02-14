using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    public class PortalUserUnifiedPagedDto : PagedResultRequestDto, ISortModel
    {
        public PortalUserUnifiedSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
