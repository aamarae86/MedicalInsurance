using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    public class PagedScCommitteesCheckResultRequestDto : PagedResultRequestDto, ISortModel
    {
        public ScCommitteesCheckSearchDto Params { get; set; }
        public SortModel OrderByValue { get; set; }
    }
}
