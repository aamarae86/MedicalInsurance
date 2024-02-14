using Abp.Application.Services.Dto;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto
{
    public class PagedApPaymentsTransactionsResultRequestDto : PagedResultRequestDto
    {
        public ApPaymentsTransactionsSearchDto Params { get; set; }
    }
}
