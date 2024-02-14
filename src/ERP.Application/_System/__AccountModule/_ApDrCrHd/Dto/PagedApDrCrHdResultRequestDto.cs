using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApDrCrHd.Dto
{
    public class PagedApDrCrHdResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ApDrCrHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
