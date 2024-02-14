using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__CharityBoxes._TmRegions;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CharityBoxes._TmLocations
{
    public class TmLocations : AuditedEntity<long>, IMustHaveTenant
    {
        public long RegionId { get;protected set; }
        [MaxLength(30)]
        public string LocationNumber { get; protected set; }
        [Required]
        [MaxLength(200)]
        public string LocationName { get; protected set; }
        public int TenantId { get ; set ; }

        [ForeignKey(nameof(RegionId))]
        public TmRegions Region { get; set; }

        public ICollection<TmLocationSub> LocationSubs { get; set; }
    }
}
