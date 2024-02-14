using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr
{
    public class FmMaintRequisitionsHdr : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string RequisitionNumber { get; protected set; }

        public long RequisitionStatusLkpId { get; protected set; }

        public long PmPropertiesId { get; protected set; }

        public long ComplaintTypeLkpId { get; protected set; }

        public long? UnitTypeLkpId { get; protected set; }

        public long? UnitId { get; protected set; }

        public DateTime? RequisitionDate { get; protected set; }

        public DateTime? RequisitionTime { get; protected set; }

        [MaxLength(150)]
        public string CallerName { get; protected set; }

        [MaxLength(30)]
        public string PhoneNumber { get; protected set; }

        [MaxLength(30)]
        public string Mobile { get; protected set; }

        [MaxLength(4000)]
        public string ComplaintDetails { get; protected set; }

        [ForeignKey(nameof(ComplaintTypeLkpId)),Column(Order = 0)]
        public FndLookupValues FndComplaintTypeLkp { get; protected set; }

        [ForeignKey(nameof(UnitTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndUnitTypeLkp { get; protected set; }

        [ForeignKey(nameof(RequisitionStatusLkpId)), Column(Order = 2)]
        public FndLookupValues FndRequisitionStatusLkp { get; protected set; }

        [ForeignKey(nameof(PmPropertiesId))]
        public PmProperties PmProperties { get; protected set; }

        [ForeignKey(nameof(UnitId))]
        public PmPropertiesUnits PmPropertiesUnits { get; protected set; }

        public int TenantId { get ; set ; }

        public void UpdateStatus(long statusLkpId) => this.RequisitionStatusLkpId = statusLkpId;
    }
}
