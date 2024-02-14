using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Parameters.ApPdcInterface
{
    public class ApPdcInterfaceParms
    {
        public long? BankAccountId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CheckNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public override string ToString()
        {
            return $"Params.BankAccountId={BankAccountId}&Params.FromDate={FromDate}&Params.ToDate={ToDate}&Params.CheckNumber={CheckNumber}&Params.StatusLkpId={StatusLkpId}";
        }
    }
}
