using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArCustomers.Dto
{
    [AutoMapFrom(typeof(ArCustomers))]
    public class PagedArCustomersResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ArCustomersSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
