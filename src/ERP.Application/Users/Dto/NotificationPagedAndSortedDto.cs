using Abp.Application.Services.Dto;

namespace ERP.Users.Dto
{
    public class NotificationPagedAndSortedDto : PagedAndSortedResultRequestDto
    {
        public NotificationSearchDto Params { get; set; }
    }
}
