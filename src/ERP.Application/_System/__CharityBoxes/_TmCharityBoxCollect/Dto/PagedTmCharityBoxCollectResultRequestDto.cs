using Abp.Application.Services.Dto;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto
{
    public class PagedTmCharityBoxCollectResultRequestDto : PagedAndSortedResultRequestDto
    {
        public TmCharityBoxCollectSearchDto Params { get; set; }

    }

}
