using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    public class PagedMasterDetailResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public MasterDetailSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
