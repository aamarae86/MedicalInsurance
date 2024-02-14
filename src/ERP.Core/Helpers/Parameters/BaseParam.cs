
using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Extensions;
using System.Collections.Generic;

namespace ERP.Core.Helpers.Parameters
{
    public class BaseParam : ITotalRecords, IPagedResultRequest, ILimitedResultRequest
    {
        public long TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortModel OrderByValue { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}
