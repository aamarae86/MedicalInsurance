using Abp.Domain.Entities;
using ERP._System.__AccountModule._ApDrCrTr;
using ERP._System._ApVendors;
using ERP._System._ArCustomers;
using ERP._System._ArDrCrTr;
using ERP._System._FndLookupValues;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AccountModule._ApDrCrHd
{
    public class ApDrCrHd : PostAuditedEntity<long>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [MaxLength(30)]
        public string HdDrCrNumber { get; protected set; }

        public DateTime? HdDate { get; protected set; }       

        [MaxLength(4000)]
        public string Comments { get; protected set; } 

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? CurrencyRate { get; protected set; }
        public long? SourceId { get; protected set; }
        
        [MaxLength(30)]
        public string SourceNo { get; protected set; }

//----- Foreign Keys
        public long? HdTypeLkpId { get; protected set; }
        public long? StatusLkpId { get; protected set; }
        public int CurrencyId { get; protected set; }
        public long? VendorId { get; protected set; }
        public long? SourceLkpId { get; protected set; }


        [ForeignKey(nameof(HdTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndLookupValuesHdTypeLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndLookupValuesStatusLkp { get; protected set; }

        [ForeignKey(nameof(SourceLkpId)), Column(Order = 2)]
        public FndLookupValues FndLookupValuesSourceLkp { get; protected set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; protected set; }

        [ForeignKey(nameof(VendorId))]
        public ApVendors Vendors { get; protected set; }

        public virtual ICollection<ApDrCrTr> ApDrCrTr { get; protected set; }
        
    }
    
}
