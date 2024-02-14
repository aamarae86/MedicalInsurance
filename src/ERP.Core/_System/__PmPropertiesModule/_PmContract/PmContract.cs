using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__PmPropertiesModule._PmCancellationContracts;
using ERP._System.__PmPropertiesModule._PmContractAttachments;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System.__PmPropertiesModule._PmTenants;
using ERP._System.__PmPropertiesModule._PmTerminateContracts;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContract
{
    public class PmContract : PostAuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string ContractNumber { get; protected set; }

        public DateTime ContractDate { get; protected set; }

        public DateTime ContractStartDate { get; protected set; }

        public DateTime ContractEndDate { get; protected set; }

        public DateTime ContractEndDatePrint { get; protected set; }

        [MaxLength(15)]
        [MinLength(15)]
        public string TaxNo { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal TaxPercent { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal RentAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal AnnualRentAmount { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? InsuranceAmount { get; protected set; }

        public long PmUnitTypeLkpId { get; protected set; }

        public long PmPaymentNoLkpId { get; protected set; }

        public long PropertyId { get; protected set; }

        public long StatusLkpId { get; protected set; }

        public long PmTenantId { get; protected set; }

        public long PmActivityLkpId { get; protected set; }

        public long? ParentContractId { get; set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        [MaxLength(4000)]
        public string Condition1 { get; protected set; }

        [MaxLength(4000)]
        public string Condition2 { get; protected set; }

        [MaxLength(4000)]
        public string Condition3 { get; protected set; }

        [MaxLength(4000)]
        public string Condition4 { get; protected set; }

        [MaxLength(4000)]
        public string Condition5 { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(PmTenantId))]
        public PmTenants PmTenants { get; set; }

        [ForeignKey(nameof(ParentContractId))]
        public PmContract Parent { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public PmProperties PmProperties { get; set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; set; }

        [ForeignKey(nameof(PmUnitTypeLkpId)), Column(Order = 2)]
        public FndLookupValues FndUnitTypeLkp { get; set; }

        [ForeignKey(nameof(PmActivityLkpId)), Column(Order = 3)]
        public FndLookupValues FndActivityLkp { get; set; }

        [ForeignKey(nameof(PmPaymentNoLkpId)), Column(Order = 4)]
        public FndLookupValues FndPaymentNoLkp { get; set; }

        public virtual ICollection<PmContractAttachments> PmContractAttachments { get; protected set; }
        public virtual ICollection<PmCancellationContracts> PmCancellationContracts { get; protected set; }
        public virtual ICollection<PmContractPayments> PmContractPayments { get; protected set; }
        public virtual ICollection<PmContractUnitDetails> PmContractUnitDetails { get; protected set; }
        public virtual ICollection<PmOtherContractPayments> PmOtherContractPayments { get; protected set; }
        public virtual ICollection<PmTerminateContracts> PmTerminateContracts { get; protected set; }
        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; protected set; }
    }
}
