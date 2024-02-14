using ERP.Front.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.DataTableHelpers
{
    public class DataTableModelParms
    {
        public string draw { get; set; }
        public int pageSize { get; set; }
        public int skip { get; set; }
        public SortModel sort { get; set; }
    }
}
