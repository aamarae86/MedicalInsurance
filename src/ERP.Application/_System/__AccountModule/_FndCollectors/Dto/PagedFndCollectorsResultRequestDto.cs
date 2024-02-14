using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._FndCollectors.Dto
{
    [AutoMapFrom(typeof(FndCollectors))]
    public class PagedFndCollectorsResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public FndCollectorsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
