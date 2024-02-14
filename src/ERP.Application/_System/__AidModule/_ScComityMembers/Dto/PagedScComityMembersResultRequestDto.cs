using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ScComityMembers.Dto
{
    [AutoMapFrom(typeof(ScComityMembers))]
    public class PagedScComityMembersResultRequestDto : PagedResultRequestDto
    {
        public ScComityMembersSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
