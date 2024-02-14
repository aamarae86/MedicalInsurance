using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._FndTaxType
{
    public class FndTaxTypeSearchDto
    {
        public string TaxTypeNumber { get; set; }
        public string TaxNameAr { get; set; }
        public string TaxNameEn { get; set; }
        public decimal Percentage { get; set; }
        public override string ToString() => $"Params.TaxTypeNumber={TaxTypeNumber}&Params.TaxNameAr={TaxNameAr}&Params.TaxNameEn={TaxNameEn}&Params.Percentage={Percentage}";

    }
}
