using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Parameters.ArCustomers
{
    public class ArCustomersParms
    {
        
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public long? CustomerNumber { get; set; } = 0;
        public long? StatusLkp { get; set; } = 0;

        public override string ToString()
        {
            return $"?Params.CustomerNumber={CustomerNumber}&Params.CustomerNameAr={CustomerNameAr}&Params.CustomerNameEn={CustomerNameEn}&Params.StatusLkp={StatusLkp}";
        }
    }
}
