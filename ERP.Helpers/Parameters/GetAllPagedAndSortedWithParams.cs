using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Front.Helpers.Core;

namespace ERP.Front.Helpers.Parameters
{
    public class GetAllPagedAndSortedWithParams<T> : IPagedAndSortParam
        where T : class
    {
        public T Params { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortModel OrderByValue { get; set; }
        public string Sorting { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }

        public override string ToString()
        {
            return $"?{Params.ToString()}&{OrderByValue.ToString()}&Sorting={Sorting}&SkipCount={SkipCount}&MaxResultCount={MaxResultCount}";
        }
    }
}
