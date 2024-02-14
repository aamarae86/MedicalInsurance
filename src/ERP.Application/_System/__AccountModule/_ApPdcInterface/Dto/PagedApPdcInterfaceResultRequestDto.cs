using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApPdcInterface.Dto
{
    [AutoMapFrom(typeof(ApPdcInterface))]
    public class PagedApPdcInterfaceResultRequestDto : PagedResultRequestDto
    {
        public ApPdcInterfaceSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
