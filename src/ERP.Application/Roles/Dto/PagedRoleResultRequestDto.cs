using Abp.Application.Services.Dto;

namespace ERP.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public RoleSearchDto Params { get; set; }
    }
}

