using Abp.AutoMapper;
using ERP._System.__AidModule._ScMaintenanceQuotations.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceContract.Dto
{
    [AutoMap(typeof(ScMaintenanceContract))]
    public class ScMaintenanceContractDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string MaintenanceContractNumber { get; set; }

        public string MaintenanceContractDate { get; set; }

        public long ScMaintenanceQuotationId { get; set; }

        public long StatusLkpId { get; set; }

        public string DurationOfImplementation { get; set; }

        public string StartDate { get; set; }

        [MaxLength(4000)]
        public string ContractTerms { get; set; }

        [MaxLength(4000)]
        public string OtherContractTerms { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public string PortalRequestNumber { get; set; }

        public string PortalUserName { get; set; }

        public string Vendor { get; set; }

        public decimal TotalAmount { get; set; }

        public long ScMaintenanceContractId { get; set; }

        public int TenantId { get; set; }

        public virtual FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual ScMaintenanceQuotationsDto ScMaintenanceQuotations { get; set; }

        public virtual ICollection<ScMaintenanceContractPaymentsDto> ScMaintenanceContractPayments { get; set; }
    }
}
