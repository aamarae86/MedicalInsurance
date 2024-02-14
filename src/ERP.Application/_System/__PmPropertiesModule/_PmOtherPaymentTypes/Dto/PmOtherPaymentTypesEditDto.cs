using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes.Dto
{
    [AutoMap(typeof(PmOtherPaymentTypes))]
    public class PmOtherPaymentTypesEditDto : EntityDto<long>
    {
        public string PaymentTypeName { get; set; }

        public long AccountId { get; set; }

        public bool IsActive { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }
    }
}
