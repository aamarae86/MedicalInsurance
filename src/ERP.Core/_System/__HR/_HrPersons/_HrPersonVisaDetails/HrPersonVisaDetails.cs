using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersons._HrPersonVisaDetails
{
    public class HrPersonVisaDetails : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(100)]
        public string VisaNumber { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? VisaCost { get; protected set; }

        public DateTime DateOfIssue { get; protected set; }

        public DateTime DateOfExpiry { get; protected set; }

        public long HrPersonId { get; protected set; }

        public long VisaTypeLkpId { get; protected set; }

        public long? PlaceOfIssueLkpId { get; protected set; }

        public long? IssuedByLkpId { get; protected set; }

        [ForeignKey(nameof(VisaTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndVisaTypeLkp { get; protected set; }

        [ForeignKey(nameof(PlaceOfIssueLkpId)), Column(Order = 1)]
        public FndLookupValues FndPlaceOfIssueLkp { get; protected set; }

        [ForeignKey(nameof(IssuedByLkpId)), Column(Order = 2)]
        public FndLookupValues FndIssuedByLkp { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        public int TenantId { get; set; }
    }
}
