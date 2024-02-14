using ERP.Common.Core;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.Helpers.Core
{
    public class DataPagging: IDataPagging
    {
        public int PageNumber { get ; set ; }
        public int PageSize { get ; set ; }
        public int TotalPage { get ; set ; }

        public IResponseResult Result { get; set; }
        public DataPagging(int pageNumber, int pageSize, int totalPage, IResponseResult result)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPage = totalPage;
            Result = result;
        }
    }
}
