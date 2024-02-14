using Abp.Application.Services.Dto;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.Dto
{
    public class PagedTmDamagedCharityBoxsResultRequestDto: PagedAndSortedResultRequestDto
    {
        public TmDamagedCharityBoxsSearchDto Params { get; set; }
    }
}
