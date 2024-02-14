using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__AccountModule._GeneralUnPost.Dto
{
    [AutoMap(typeof(GeneralUnPost))]
    public class GeneralUnPostEditDto : EntityDto<long>
    {
        public string UnPostNo { get; set; }

        public long SourceLkpId { get; set; }

        public long? ApMiscPaymentHeadersId { get; set; }

        public string SourceNo { get; set; }

        public string Notes { get; set; }

        public string RefuseReason { get; set; }
        public long? ArJobCardHdId { get; protected set; }
    }
}
