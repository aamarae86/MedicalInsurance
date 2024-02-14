using Abp.AutoMapper;

namespace ERP._System._GlJeLines.Dto
{
    [AutoMap(typeof(GlJeLines))]
    [AutoMapTo(typeof(GlJeLines))]
    [AutoMapFrom(typeof(GlJeLines))]
    public class GlJeLinesDto: Abp.Application.Services.Dto.EntityDto<long>
    {

        public decimal DebitAmount { get;  set; }

        public decimal CreditAmount { get;  set; }

        public long AccountId { get;  set; }

        public long GlJeHeaderId { get;  set; }

        public long? JeDtlSourceLkpId { get;  set; }

        public long? JeSourceId { get;  set; }

        public string Notes { get;  set; }
    }
}
