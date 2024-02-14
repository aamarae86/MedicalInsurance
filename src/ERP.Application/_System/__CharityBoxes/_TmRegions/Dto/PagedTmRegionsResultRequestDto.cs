using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmRegions.Dto
{
    [AutoMapFrom(typeof(TmRegions))]
    public class PagedTmRegionsResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public TmRegionsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
