using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System._ArSecurityDepositInterface.Dto
{
    public class PagedArSecurityDepositInterfaceResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArSecurityDepositInterfaceSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
