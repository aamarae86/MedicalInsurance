using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._GeneralUnPost.Input
{
    public class GeneralPostUnPostInput : IMustHaveTenant
    {
        [MaxLength(30)]
        public string UnPostNo { get; set; }

        public DateTime UnPostDate => DateTime.Now;

        public long SourceLkpId { get; set; }

        public long? ApMiscPaymentHeadersId { get; set; }

        public string SourceNo { get; set; }

        public string Notes { get; set; }

        public string RefuseReason { get; set; }

        public long? ArMiscReceiptHeadersId { get; set; }

        public long? PmContractId { get; set; }

        public long? ScCommitteesId { get; set; }

        public long? ScPortalRequestMgrDecisionId { get; set; }

        public long? GlJeHeaderId { get; set; }
        public long? ArJobCardHdId { get; set; }

        public string Lang { get; set; }

        public long UserId { get; set; }
       

        public int TenantId { get; set; }
    }
}
