using Abp.AutoMapper;
using System;

namespace ERP._System.__AccountModule._GeneralUnPost.Dto
{
    [AutoMap(typeof(GeneralUnPost))]
    public class CreateGeneralUnPostDto
    {
        public string UnPostNo { get; set; }

        public DateTime UnPostDate { get; set; }

        public long SourceLkpId { get; set; }

        public long? ApMiscPaymentHeadersId { get; set; }

        public string SourceNo { get; set; }

        public string Notes { get; set; }

        public string RefuseReason { get; set; }

        public string Lang { get; set; }
        public long? ArJobCardHdId { get; protected set; }
    }
}
