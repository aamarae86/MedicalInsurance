using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceContract.Dto
{
    [AutoMap(typeof(ScMaintenanceContract))]
    public class ScMaintenanceContractEditDto : EditEntityDto<long>
    {
        public string MaintenanceContractDate { get; set; }

        public long ScMaintenanceQuotationId { get; set; }

        public string DurationOfImplementation { get; set; }

        public string StartDate { get; set; }

        [MaxLength(4000)]
        public string ContractTerms { get; set; }

        [MaxLength(4000)]
        public string OtherContractTerms { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScMaintenanceContractPaymentsDto> MaintenanceContractPayments { get; set; }
    }
}
