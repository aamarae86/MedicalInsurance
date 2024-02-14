using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrPersons._HrPersonPassportDetails
{
    public class HrPersonPassportDetails : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(100)]
        public string PassportNumber { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string PlaceOfIssue { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public DateTime DateOfIssue { get; protected set; }

        public DateTime DateOfExpiry { get; protected set; }

        public long HrPersonId { get; protected set; }

        public long PassportTypeLkpId { get; protected set; }

        public long CountryOfIssueLkpId { get; protected set; }

        [ForeignKey(nameof(PassportTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndPassportTypeLkp { get; protected set; }

        [ForeignKey(nameof(CountryOfIssueLkpId)), Column(Order = 1)]
        public FndLookupValues FndCountryOfIssueLkp { get; protected set; }

        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }

        public int TenantId { get; set; }
    }
}
