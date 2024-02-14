using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    public class rptGlAccMappingHdHelperInput
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

        public long TenantId { get; set; }

        public long PeriodIdFrom { get; set; }
        public string PeriodIdFromtxt { get; set; }

        public long PeriodIdTo { get; set; }
        public string PeriodIdTotxt { get; set; }

        public long GlAccMappingHdId { get; set; }
        public string GlAccMappingHdIdtxt { get; set; }

        public string Lang { get; set; }

        public override string ToString() =>
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
            $"&TenantId={TenantId}&PeriodIdFrom={PeriodIdFrom}&PeriodIdTo={PeriodIdTo}&GlAccMappingHdId={GlAccMappingHdId}&Lang={Lang}";
    }
}
