using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmLocations
{
    public class TmLocationSub : AuditedEntity<long>, IMustHaveTenant
    {
        public long LocationId { get;protected set; }
        [ForeignKey(nameof(LocationId))]
        public TmLocations TmLocation { get; protected set; }

        [MaxLength(30)]
        public string TmLocationSubNumber { get; protected set; }
        [Required]
        [MaxLength(200)]
        public string TmLocationSubName { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public int TenantId { get ; set ; }
    }
}
