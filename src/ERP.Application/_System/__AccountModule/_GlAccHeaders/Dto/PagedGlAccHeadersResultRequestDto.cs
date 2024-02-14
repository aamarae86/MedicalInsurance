using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccHeaders.Dto
{
    [AutoMapFrom(typeof(GlAccHeaders))]
    public class PagedGlAccHeadersResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public GlAccHeadersSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
