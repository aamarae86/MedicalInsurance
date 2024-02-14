using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._FndSalesMen.Dto
{
    [AutoMapFrom(typeof(FndSalesMen))]
    public class PagedFndSalesMenResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public FndSalesMenSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
