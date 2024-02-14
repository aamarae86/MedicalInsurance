using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._FndLookupValues;
using ERP._System._GlJeHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AccountModule._GeneralUnPost
{
    public class GeneralUnPost : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string UnPostNo { get; protected set; }
        public DateTime UnPostDate { get;protected set; }
        public long SourceLkpId { get;protected set; }
        public long? ApMiscPaymentHeadersId { get;protected set; }
        [MaxLength(30)]
        public string SourceNo { get; protected set; }
        [MaxLength]
        public string Notes { get; protected set; }
        [MaxLength]
        public string RefuseReason { get; protected set; }
        public int TenantId { get; set; }

        public long? ArMiscReceiptHeadersId { get;protected set; }
        public long? PmContractId { get;protected set; }
        public long? ScCommitteesId { get;protected set; }
        public long? ScPortalRequestMgrDecisionId { get; protected set; }
        public long? GlJeHeaderId { get; protected set; }

        [ForeignKey(nameof(SourceLkpId))]
        public FndLookupValues FndLookupGeneralUnPostSourceLkp { get;protected set; }

        [ForeignKey(nameof(ApMiscPaymentHeadersId))]
        public ApMiscPaymentHeaders ApMiscPaymentHeaders { get; protected set; }

        [ForeignKey(nameof(ArMiscReceiptHeadersId))]
        public ArMiscReceiptHeaders ArMiscReceiptHeaders { get; protected set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; protected set; }

        [ForeignKey(nameof(ScCommitteesId))]
        public ScCommittee ScCommittee { get; protected set; }

        [ForeignKey(nameof(ScPortalRequestMgrDecisionId))]
        public ScPortalRequestMgrDecision ScPortalRequestMgrDecision { get; protected set; }

        [ForeignKey(nameof(GlJeHeaderId))]
        public GlJeHeaders GlJeHeaders { get; protected set; }

        public long? ArJobCardHdId { get; protected set; }

        [ForeignKey(nameof(ArJobCardHdId))]
        public ArJobCardHd ArJobCardHd { get; protected set; }

      
    }
}
