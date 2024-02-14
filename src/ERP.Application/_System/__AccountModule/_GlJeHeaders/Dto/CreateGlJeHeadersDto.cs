using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System._GlJeHeaders.Dto
{
    [AutoMap(typeof(GlJeHeaders))]
    public class CreateGlJeHeadersDto
    {
        public string JeName { get; set; }

        public string JeNumber { get; set; }

        public int JeNumberKey { get; set; }

        public string JeDate { get; set; }

        public long? PeriodId { get; set; }

        public int CurrencyId { get; set; }

        public decimal CurrencyRate { get; set; }

        public Nullable<long> JeSourceId { get; set; }

        public string JeNotes { get; set; }

        public string JeSourceNo { get; set; }

        public Nullable<long> StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_GlJeHeadersStatues);

        public Nullable<long> JeSourceLkpId => Convert.ToInt64(FndEnum.FndLkps.Manual_GlJeHeadersReferenceType);

        public List<GlJeLinesDetailsVM> GlJeLinesDetailsVM { get; set; }
    }

}
