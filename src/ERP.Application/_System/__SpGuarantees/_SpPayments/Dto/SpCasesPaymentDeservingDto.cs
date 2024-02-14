using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    [AutoMap(typeof(SpCasesPaymentDeserving))]
    public class SpCasesPaymentDeservingDto : EntityDto<long>, IDetailRowStatus
    {

        public string rowStatus { get; set; }
    }
}
