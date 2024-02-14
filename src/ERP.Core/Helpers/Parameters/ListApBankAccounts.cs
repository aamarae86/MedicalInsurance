using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Helpers.Parameters
{
    public class ListApBankAccounts : CodeComUtility, IDetailRowStatus
    {
        public int index { get; set; }

        public long? apBankAccId { get; set; }

        public string bankAccountNameAr { get; set; }

        public string bankAccountNameEn { get; set; }

        public int currencyId { get; set; }

        public decimal currencyRate { get; set; }

        public string currency { get; set; }

        public bool IsActive => true;

        public string rowStatus { get; set; }
    }
}
