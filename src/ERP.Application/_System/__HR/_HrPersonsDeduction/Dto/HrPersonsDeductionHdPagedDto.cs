using Abp.Application.Services.Dto;

namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    public class HrPersonsDeductionHdPagedDto : PagedAndSortedResultRequestDto
    {
        public HrPersonsDeductionHdSearchDto Params { get; set; }
    }
}
