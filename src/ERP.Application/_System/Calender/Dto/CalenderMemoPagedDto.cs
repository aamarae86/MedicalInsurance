using Abp.Application.Services.Dto;

namespace ERP._System.Calender.Dto
{
    public class CalenderMemoPagedDto : PagedAndSortedResultRequestDto
    {
        public CalenderMemoSearchDto Params { get; set; }

    }
}
