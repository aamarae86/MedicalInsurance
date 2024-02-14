using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmContactUs
{
    public class CrmContactUs : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string HeaderNameAr { get; protected set; }

        [MaxLength(200)]
        [Required]
        public string HeaderNameEn { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string ContentAr { get; protected set; }

        [Required]
        [MaxLength(4000)]
        public string ContentEn { get; protected set; }

        [MaxLength(50)]
        public string Phone1 { get; protected set; }

        [MaxLength(50)]
        public string Phone2 { get; protected set; }

        [MaxLength(50)]
        public string Fax { get; protected set; }

        [MaxLength(30)]
        public string WorkingHours { get; protected set; }

        [MaxLength(30)]
        public string Email { get; protected set; }

        [MaxLength(4000)]
        public string FilePath { get; protected set; }
 
        [MaxLength(4000)]
        public string Address { get; protected set; }

        public int TenantId { get; set ; }
    }
}
