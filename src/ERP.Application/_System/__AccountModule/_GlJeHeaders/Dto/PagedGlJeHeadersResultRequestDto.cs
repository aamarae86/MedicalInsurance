using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.Dto
{
   public  class PagedGlJeHeadersResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public GlJeHeadersSearchDto Params { get; set; }
        public SortModel OrderByValue { get ; set ; }
    }
}
