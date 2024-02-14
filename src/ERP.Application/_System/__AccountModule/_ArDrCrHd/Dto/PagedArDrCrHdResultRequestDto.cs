using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArDrCrHd.Dto
{
    public class PagedArDrCrHdResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArDrCrHdSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
