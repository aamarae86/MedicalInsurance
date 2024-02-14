using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System._FndLookupValues.Dto;

namespace ERP._System.__AccountModule._GeneralUnPost
{
    [AutoMap(typeof(GeneralUnPost))]
    public class GeneralUnPostDto : AuditedEntityDto<long>
    {
        public string UnPostNo { get; set; }

        public string UnPostDate { get; set; }

        public long SourceLkpId { get; set; }

        public long? ApMiscPaymentHeadersId { get; set; }

        public string SourceNo { get; set; }

        public string Notes { get; set; }

        public string RefuseReason { get; set; }

        public long? ArMiscReceiptHeadersId { get; set; }

        public long? PmContractId { get; set; }

        public long? ScCommitteesId { get; set; }

        public long? ScPortalRequestMgrDecisionId { get; set; }
        public long? ArJobCardHdId { get; protected set; }

        public FndLookupValuesDto FndLookupGeneralUnPostSourceLkp { get; set; }

        public ApMiscPaymentHeadersDto ApMiscPaymentHeaders { get; set; }

    }
}
