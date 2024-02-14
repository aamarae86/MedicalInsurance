using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmPropertiesUnits
{
    public class PmPropertiesUnits : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string UnitNo { get; protected set; }

        [MaxLength(30)]
        public string ElectricityNumber { get; protected set; }

        [MaxLength(30)]
        public string SewerageNumber { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? AreaSize { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal YearlyRent { get; protected set; }

        [MaxLength(30)]
        public string FloorLevel { get; protected set; }

        [MaxLength(4000)]
        public string Description { get; protected set; }

        public long PmUnitTypeLkpId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long? ViewLkpId { get; protected set; }

        public long? FinishesLkpId { get; protected set; }

        public long PropertyId { get; protected set; }

        public long? PmUnitDescLkpId { get; protected set; }

        [ForeignKey(nameof(PropertyId))]
        public PmProperties PmProperties { get; protected set; }

        [ForeignKey(nameof(PmUnitTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndUnitTypeLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(ViewLkpId)), Column(Order = 2)]
        public FndLookupValues FndViewLkp { get; protected set; }

        [ForeignKey(nameof(FinishesLkpId)), Column(Order = 3)]
        public FndLookupValues FndFinishesLkp { get; protected set; }

        [ForeignKey(nameof(PmUnitDescLkpId)), Column(Order = 4)]
        public FndLookupValues FndPmUnitDescLkp { get; protected set; }

        public virtual ICollection<PmContractUnitDetails> PmContractUnitDetails { get; protected set; }

        public virtual ICollection<PmPropertiesUnitsAttachments> PmPropertiesUnitsAttachments { get; protected set; }
    
        public virtual ICollection<FmMaintRequisitionsHdr> FmMaintRequisitionsHdr { get; protected set; }

        public int TenantId { get; set; }
    }
}
