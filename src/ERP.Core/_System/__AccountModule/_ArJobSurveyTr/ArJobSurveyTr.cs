using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Stripe;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__AccountModule._ArJobSurveyHd;
using ERP._System.__AccountModule._ArJobSurveyPartsList;
using ERP._System._FndLookupValues;

namespace ERP._System.__AccountModule._ArJobSurveyTr
{
    public class ArJobSurveyTr : AuditedEntity<long>, IMustHaveTenant
    {
        public long? ArJobSurveyHdId { get; set; }
        [ForeignKey(nameof(ArJobSurveyHdId))]
        public ArJobSurveyHd ArJobSurveyHd { get; protected set; }
        public long? ArJobSurveyPartsId { get; set; }
        [ForeignKey(nameof(ArJobSurveyPartsId))]
        public ArJobSurveyPartsList ArJobSurveyPartsList { get; protected set; }
        public long? PartsCategoryLkpId { get; set; }
        [ForeignKey(nameof(PartsCategoryLkpId)), Column(Order = 0)]
        public FndLookupValues PartsCategoryLkp { get; protected set; }
        public bool IsRepair { get; set; }
        public bool IsReplace { get; set; }
        public int TenantId { get; set; }
    }
}
