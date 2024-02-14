using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScMaintenanceContract.Dto
{
    [AutoMap(typeof(ScMaintenanceContractPayments))]
    public class ScMaintenanceContractPaymentsDto : EntityDto<long>, IDetailRowStatus
    {
        public long ScMaintenanceContractId { get; set; }

        public int PayemtNo { get; set; }

        public decimal Amount { get; set; }

        public string PaymentCondition { get; set; }

        public string MaturityDate { get; set; }

        public string rowStatus { get; set; }
    }
}
