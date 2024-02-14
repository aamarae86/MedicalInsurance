using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Stripe;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System._FndLookupValues;

namespace ERP._System.__AccountModule._ArJobSurveyPartsList
{
    public class ArJobSurveyPartsList : AuditedEntity<long>, IMustHaveTenant
    {

        [Required]
        [MaxLength(30)]
        public string PartsNumber { get; set; }
        [Required]
        public string PartsName { get; set; }
        public long? PartsCategoryLkpId { get; set; }
        [ForeignKey(nameof(PartsCategoryLkpId)), Column(Order = 0)]
        public FndLookupValues PartsCategoryLkp  { get; protected set; }
        public int TenantId { get; set; }


    }
}
