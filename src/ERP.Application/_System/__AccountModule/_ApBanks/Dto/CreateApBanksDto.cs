using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApBanks.Dto
{
    public class CreateApBanksDto
    {
        public string BankNameAr { get;  set; }
        public string BankNameEn { get;  set; }
        public long BankTypeLkpId { get;  set; }
        public bool IsActive { get; set; }

        public List<ListApBankAccounts> ListApBankAccountsDetails { get; set; }
    }
     
}
