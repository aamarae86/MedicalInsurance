using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes.Dto
{
    [AutoMap(typeof(PmOtherPaymentTypes))]
    public class CreatePmOtherPaymentTypesDto
    {
        public string PaymentTypeName { get; set; }
        public long AccountId { get; set; }
        public bool IsActive { get; set; }
        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }
    }
}
