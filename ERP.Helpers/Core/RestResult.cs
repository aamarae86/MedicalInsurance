using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Core
{
    public class RestResult
    {
        public Object result { get; set; }

        public string targetUrl { get; set; }
        public bool success { get; set; }
        public ErrorResult error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }

        public CustomRestResult customRestResult { get; set; }
    }
}
