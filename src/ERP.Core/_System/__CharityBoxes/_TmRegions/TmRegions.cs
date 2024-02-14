using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Services;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmRegions
{
    public class TmRegions : AuditedEntity<long>, IMustHaveTenant
    {
        public long CityLkpId { get;protected set; }
        [MaxLength(30)]
        public string RegionNumber { get; protected set; }
        [Required]
        [MaxLength(200)]
        public string RegionName { get; protected set; }
        public int TenantId { get ; set ; }

        [ForeignKey(nameof(CityLkpId))]
        public FndLookupValues FndLookupValues { get; set; }
    }
}
