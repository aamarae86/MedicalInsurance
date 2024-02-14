using Abp.Domain.Entities;
using ERP._System.__AccountModule._TmCharityBoxesType;
using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive
{
    public class TmCharityBoxReceive : PostAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public DateTime ReceiveDate { get; protected set; }

        [Required]
        [MaxLength(30)]
        public string ReceiveNumber { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValues { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string SupplierName { get; protected set; }

        public long CharityTypeId { get; protected set; }

        [ForeignKey(nameof(CharityTypeId))]
        public TmCharityBoxesType CharityBoxesType { get; protected set; }

        public long NoOfCharityBox { get; protected set; }

        public decimal AmountCharityBox { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public virtual ICollection<TmCharityBoxes> TmCharityBoxes { get; protected set; }
    }
}
