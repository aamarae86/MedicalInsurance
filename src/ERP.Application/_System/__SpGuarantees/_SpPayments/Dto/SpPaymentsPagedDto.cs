using Abp.Application.Services.Dto;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    public class SpPaymentsPagedDto : PagedAndSortedResultRequestDto
    {
        public SpPaymentsSearchDto Params { get; set; }
    }
}
