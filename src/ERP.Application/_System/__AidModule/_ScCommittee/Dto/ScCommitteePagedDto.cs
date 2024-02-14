using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScCommittee.Dto
{
    public class ScCommitteePagedDto : PagedResultRequestDto, ISortModel
    {
        public ScCommitteeSearchDto Params { get; set; }

        public SortModel OrderByValue { get; set; }
    }
}
