using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes.Dto
{
    public class PagedPmOtherPaymentTypesResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public PmOtherPaymentTypesSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
