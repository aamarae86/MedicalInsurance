using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ScComityMembers;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ScCampainsAid.Dto
{
    [AutoMapFrom(typeof(ScCampainsAid))]
    public class PagedScCampainsAidResultRequestDto : PagedResultRequestDto
    {
        public ScCampainsAidSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
