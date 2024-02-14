using Abp.Application.Services.Dto;

namespace ERP._System.__CharityBoxes._TmCharityBoxActions.Dto
{
    public class PagedTmCharityBoxActionsResultRequestDto : PagedAndSortedResultRequestDto
    {
        public TmCharityBoxActionsSearchDto Params { get; set; }
    }
}
