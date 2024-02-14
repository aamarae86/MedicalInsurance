using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;

namespace ERP.Users.Dto
{
    public class PagedUserResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public UserSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
