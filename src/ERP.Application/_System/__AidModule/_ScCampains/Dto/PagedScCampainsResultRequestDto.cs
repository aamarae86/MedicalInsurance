using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    public class PagedScCampainsResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ScCampainsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
