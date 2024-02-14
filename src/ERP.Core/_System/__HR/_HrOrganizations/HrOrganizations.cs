using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrPersons;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__HR._HrOrganizations
{
    public class HrOrganizations : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string OrganizationName { get; protected set; }

        [MaxLength(200)]
        public string ShortName { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [MaxLength(2000)]
        public string ParentPath { get; protected set; }

        public long OrganizationTypeLkpId { get; protected set; }

        public long? ParentId { get; protected set; }

        [ForeignKey(nameof(ParentId))]
        public HrOrganizations Parent { get; protected set; }

        [ForeignKey(nameof(OrganizationTypeLkpId))]
        public FndLookupValues FndOrganizationTypeLkp { get; protected set; }

        [InverseProperty(nameof(HrPersons.HrOrganizationsDept))]
        public virtual ICollection<HrPersons> HrOrganizationsDeptCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.HrOrganizationsBranch))]
        public virtual ICollection<HrPersons> HrOrganizationsBranchCollection { get; protected set; }

        public int TenantId { get; set; }
    }
}
