using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Core
{
    public class ReturnObject
    {
        public SortModel GetSortModels(string sortColumn, string sortColumnDir)
        {
            return new SortModel()
            {
                ColId = sortColumn,
                Sort = sortColumnDir
            };
        }
    }
}
