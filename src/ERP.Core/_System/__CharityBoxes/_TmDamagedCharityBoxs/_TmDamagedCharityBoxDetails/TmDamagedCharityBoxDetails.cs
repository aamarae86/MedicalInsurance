using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs._TmDamagedCharityBoxDetails
{
    public class TmDamagedCharityBoxDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long TmDamagedCharityBoxId { get; protected set; }

        public long CharityBoxActionDetailId { get; protected set; }

        [MaxLength(4000)]
        public string DamageReason { get; protected set; }

        [ForeignKey(nameof(TmDamagedCharityBoxId))]
        public TmDamagedCharityBoxs TmDamagedCharityBoxs { get; protected set; }

        [ForeignKey(nameof(CharityBoxActionDetailId))]
        public TmCharityBoxActionDetails TmCharityBoxActionDetails { get; protected set; }

        public int TenantId { get; set; }

    }
}
