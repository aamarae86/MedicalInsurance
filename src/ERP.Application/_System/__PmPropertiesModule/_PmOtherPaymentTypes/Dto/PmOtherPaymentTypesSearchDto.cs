using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes.Dto
{
    public class PmOtherPaymentTypesSearchDto
    {
        public string PaymentTypeName { get;  set; }
        public override string ToString() => $"Params.PaymentTypeName={PaymentTypeName}";
    }
}
