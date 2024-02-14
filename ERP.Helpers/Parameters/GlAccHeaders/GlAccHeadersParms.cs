using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Front.Helpers.Parameters.GlAccHeaders
{
    public class GlAccHeadersParms
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public override string ToString()
        {
            return $"Params.NameAr={NameAr}&Params.NameEn={NameEn}";
        }
    }
}
