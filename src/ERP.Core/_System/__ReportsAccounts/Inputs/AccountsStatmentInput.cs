using Abp.AutoMapper;
using ERP._System._GlAccDetails;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    [AutoMap(typeof(AccountsStatmentHelperInput))]
    public class AccountsStatmentInput
    {
        public long? Attribute1 { get; set; }

        public long? Attribute2 { get; set; }

        public long? Attribute3 { get; set; }

        public long? Attribute4 { get; set; }

        public long? Attribute5 { get; set; }

        public long? Attribute6 { get; set; }

        public long? Attribute7 { get; set; }

        public long? Attribute8 { get; set; }

        public long? Attribute9 { get; set; }

        public long? AccId { get; set; }

        public long? AccId0 { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Lang { get; set; }

    }
}
