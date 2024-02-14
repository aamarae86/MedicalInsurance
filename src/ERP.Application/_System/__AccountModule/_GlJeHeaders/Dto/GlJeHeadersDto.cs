using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Core.Helpers.Core;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System._GlJeHeaders.Dto
{
    [AutoMap(typeof(GlJeHeaders))]
    public class GlJeHeadersDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

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

        public Nullable<long> StatusLkpId { get; set; }

        public Nullable<long> JeSourceLkpId { get; set; }

        public List<GlJeLinesDetailsVM> GlJeLinesDetailsVM { get; set; }

        public FndLookupValuesDto StatusFndLookupValues { get; set; }

        public FndLookupValuesDto JeSourceFndLookupValues { get; set; }

        public GlPeriodsDetailsDto GlPeriodsDetails { get; set; }

        public CurrencyDto Currency { get; set; }

        public bool ValidActionAfterPostStatus { get; set; }
    }
}
