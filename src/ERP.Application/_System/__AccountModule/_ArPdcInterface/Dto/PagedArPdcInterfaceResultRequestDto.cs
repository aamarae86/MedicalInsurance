using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArPdcInterface.Dto
{
    [AutoMapFrom(typeof(ArPdcInterface))]
    public class PagedArPdcInterfaceResultRequestDto : PagedResultRequestDto
    {
        public ArPdcInterfaceSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
