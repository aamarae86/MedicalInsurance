using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Core
{
    public class Items<T> where T : class
    {
        public List<T> items { get; set; }

        public int totalRecords { get; set; }
    }
}
