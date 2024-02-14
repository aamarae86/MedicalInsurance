using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    public class AccountsStatmentHelperInput 
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

        public string FromDateStr { get; set; }

        public string ToDateStr { get; set; }

        public string Lang { get; set; }

        public override string ToString()=> 
            $"?Attribute1={Attribute1}" +
            $"&Attribute2={Attribute2}" +
            $"&Attribute3={Attribute3}" +
            $"&Attribute4={Attribute4}" +
            $"&Attribute5={Attribute5}" +
            $"&Attribute6={Attribute6}" +
            $"&Attribute7={Attribute7}" +
            $"&Attribute8={Attribute8}" +
            $"&Attribute9={Attribute9}" +
            $"&AccId={AccId}" +
            $"&AccId0={AccId0}" +
            $"&FromDateStr={FromDateStr}&ToDateStr={ToDateStr}&Lang={Lang}";
    }
}
