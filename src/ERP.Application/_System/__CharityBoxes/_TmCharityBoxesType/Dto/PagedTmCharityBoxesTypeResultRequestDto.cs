using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._TmCharityBoxesType.Dto
{
    [AutoMapFrom(typeof(TmCharityBoxesType))]
    public class PagedTmCharityBoxesTypeResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public TmCharityBoxesTypeSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
