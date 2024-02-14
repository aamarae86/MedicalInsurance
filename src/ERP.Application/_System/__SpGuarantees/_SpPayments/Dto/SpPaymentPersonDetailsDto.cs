using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpPayments.Dto
{
    [AutoMap(typeof(SpPaymentPersonDetails))]
    public class SpPaymentPersonDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long SpPaymentPersonId { get; set; }

        public long SpContractDetailsId { get; set; }

        public long PeriodId { get; set; }

        public long? SpCasesPaymentDeservingId { get; set; }

        public string ContractStartDate { get; set; }

        public string ContractEndDate { get; set; }

        public decimal ContractAmount { get; set; }

        public decimal ManagementPercentage { get; set; }

        public string PeriodAr { get; set; }

        public string PeriodEn { get; set; }

        public string StatusAr { get; set; }

        public string StatusEn { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string CaseName { get; set; }

        public string rowStatus { get; set; }
    }
}
