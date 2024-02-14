using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenancePayments.Dto
{
    [AutoMap(typeof(ScMaintenancePayments))]
    public class ScMaintenancePaymentsEditDto : EditEntityDto<long>
    {
        public string MaintenancePaymentDate { get; set; }

        public string MaturityDate { get; set; }

        public long ScMaintenanceContractPaymentId { get; set; }

        public decimal AchievementRate { get; set; }

        public decimal Amount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }
    }
}
