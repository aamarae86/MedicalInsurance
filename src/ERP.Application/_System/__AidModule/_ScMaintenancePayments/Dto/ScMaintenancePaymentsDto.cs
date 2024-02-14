using Abp.AutoMapper;
using ERP._System.__AidModule._ScMaintenanceContract.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenancePayments.Dto
{
    [AutoMap(typeof(ScMaintenancePayments))]
    public class ScMaintenancePaymentsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string MaintenancePaymentNumber { get; set; }

        public string MaintenanceContractNumber { get; set; }

        public string MaintenancePaymentDate { get; set; }

        public string MaturityDate { get; set; }

        public long StatusLkpId { get; set; }

        public long ScMaintenanceContractPaymentId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public decimal AchievementRate { get; set; }

        public long ScMaintenanceContractId { get; set; }

        public decimal Amount { get; set; }

        public string PortalRequestNumber { get; set; }

        public string PortalUserName { get; set; }

        public string Vendor { get; set; }

        public string MaintenanceContractPaymentsNumber { get; set; }

        public virtual FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual ScMaintenanceContractPaymentsDto ScMaintenanceContractPayments { get; set; }
    }
}
