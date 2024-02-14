using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Helpers.Parameters.ArCustomers.ApBanks
{
    public class ApBanksParms
    {
        public string BankNameAr { get; set; }
        public string BankNameEn { get; set; }
        public long? BankTypeLkpId { get; set; }

        public override string ToString()=>$"Params.BankNameAr={BankNameAr}&Params.BankNameEn={BankNameEn}&Params.BankTypeLkpId={BankTypeLkpId}";
    }
}
