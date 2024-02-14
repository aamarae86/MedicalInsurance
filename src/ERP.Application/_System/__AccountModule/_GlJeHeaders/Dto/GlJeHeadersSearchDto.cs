using Abp.AutoMapper;
using System;

namespace ERP._System._GlJeHeaders.Dto
{
    [AutoMapTo(typeof(GlJeHeaders))]
    public class GlJeHeadersSearchDto
    {
        public string JeName { get; set; }

        public string JeNumber { get; set; }

        public string JeDate { get; set; }

        public int? CurrencyId { get; set; }

        public long? StatusLkpId { get; set; }

        public long? JeSourceLkpId { get; set; }
    }
}
