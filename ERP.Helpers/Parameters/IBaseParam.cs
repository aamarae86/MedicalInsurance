using Abp.Application.Services.Dto;
using ERP.Front.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Parameters
{
    public interface IBaseParam : IPagedResultRequest, ILimitedResultRequest
    {
        int PageNumber { get; set; } // SkipCount
        int PageSize { get; set; } // MaxResultCount
         SortModel OrderByValue { get; set; }
    }

    public interface IPagedAndSortParam : IBaseParam
    {
    }
}
