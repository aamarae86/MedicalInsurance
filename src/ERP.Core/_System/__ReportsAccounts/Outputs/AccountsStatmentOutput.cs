using System;

namespace ERP._System.__ReportsAccounts.Outputs
{
    public class AccountsStatmentOutput 
    {
        public string ACCOUNT_CODE { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string JE_NAME { get; set; }
        public DateTime JE_DATE { get; set; }
        public string JE_SOURCE_DESC { get; set; }
        public string NOTES { get; set; }
        public decimal DEBIT_AMOUNT { get; set; }
        public decimal CREDIT_AMOUNT { get; set; }
        public string ROW_TYPE { get; set; }
    }
}
