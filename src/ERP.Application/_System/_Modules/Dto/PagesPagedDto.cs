using Abp.Application.Services.Dto;

namespace ERP._System._Modules.Dto
{
    public class PagesPagedDto : PagedAndSortedResultRequestDto
    {
        public PagesSearchDto Params { get; set; }
    }
}
