using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContract.Dto
{
    public class PagedPmContractResultRequestDto : PagedAndSortedResultRequestDto, ISortModel
    {
        public PmContractSearchDto Params { get; set; }

        public SortModel OrderByValue { get ; set ; }
    }
}
