using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Parameters.ArPdcInterface
{
    public class ArPdcInterfaceParms
    {
        public long? BankAccountId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CheckNumber { get; set; }
        public decimal? Amount { get; set; }
        public long? StatusLkpId { get; set; }
        public override string ToString()
        {
            return $"Params.BankAccountId={BankAccountId}&Params.FromDate={FromDate}&Params.ToDate={ToDate}&Params.CheckNumber={CheckNumber}&Params.Amount={Amount}&Params.StatusLkpId={StatusLkpId}";
        }
    }
}
