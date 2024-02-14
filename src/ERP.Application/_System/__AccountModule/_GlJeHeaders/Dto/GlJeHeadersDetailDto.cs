using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues;
using ERP._System._GlPeriods;
using ERP.Currencies.Dto;
using System;

namespace ERP._System._GlJeHeaders.Dto
{
    [AutoMapFrom(typeof(GlJeHeaders))]
    public class GlJeHeadersDetailDto : EntityDto<long>
    {
        public string JeName { get; set; }

        public string JeNumber { get; set; }

        public int JeNumberKey { get; set; }

        public string JeDate { get; set; }

        public long PeriodId { get; set; }

        public int CurrencyId { get; set; }

        public decimal CurrencyRate { get; set; }

        public Nullable<long> JeSourceId { get; set; }

        public string JeNotes { get; set; }

        public string JeSourceNo { get; set; }

        public CurrencyDto Currency { get; set; }

        public Nullable<long> StatusLkpId { get; set; }
        public Nullable<long> JeSourceLkpId { get; set; }

        public FndLookupValues StatusFndLookupValues { get; set; }
        public FndLookupValues JeSourceFndLookupValues { get; set; }

        public GlPeriodsDetails GlPeriodsDetails { get; set; }

    }
}
