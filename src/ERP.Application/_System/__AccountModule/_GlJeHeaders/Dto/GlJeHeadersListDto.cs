using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Security;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Currencies.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.Dto
{
    [AutoMapFrom(typeof(GlJeHeaders))]
    public class GlJeHeadersListDto : AuditedEntity<long>
    {
        public string EncId => Core.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());
        public string JeName { get;  set; }
        public string JeNumber { get;  set; }
        public int JeNumberKey { get;  set; }
        public DateTime JeDate { get;  set; }
        public long PeriodId { get;  set; }
        public int CurrencyId { get;  set; }
        public decimal CurrencyRate { get; set; }
        public Nullable<long> JeSourceId { get; set; }
        public string JeNotes { get;  set; }
        public string JeSourceNo { get;  set; }
        public Nullable<long> StatusLkpId { get;  set; }
        public Nullable<long> JeSourceLkpId { get;  set; }

        public string JeDateStrDis => this.JeDate.ToString("yyyy/MM/dd");

        public FndLookupValuesDto StatusFndLookupValues { get; set; }
        public FndLookupValuesDto JeSourceFndLookupValues { get; set; }
        public GlPeriodsDetailsDto GlPeriodsDetails { get; set; }
        public CurrencyDto Currency { get; set; }
    }
}
