using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Parameters.GlAccDetails
{
    public class GlAccDetailsParms
    {
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public long? GlAccHeaderId { get; set; }

        public override string ToString() => $"?Params.Code={Code}&Params.NameAr={NameAr}&Params.NameEn={NameEn}&Params.GlAccHeaderId={GlAccHeaderId}";
         
    }
}
