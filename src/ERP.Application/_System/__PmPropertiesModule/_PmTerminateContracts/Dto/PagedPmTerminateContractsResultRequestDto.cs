using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts.Dto
{
    public class PagedPmTerminateContractsResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public PmTerminateContractsSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
