using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._GlJeHeaders;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._GlJeHeaders.Dto
{
    [AutoMap(typeof(GlJeHeaders))]
    public class GlJeHeadersEditDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string JeName { get; set; }
        public string JeNumber { get; set; }
        public int JeNumberKey { get; set; }

        public string JeDate { get; set; }

        public long PeriodId { get; set; }

        public int CurrencyId { get; set; }

        public decimal CurrencyRate { get; set; }

        public string JeNotes { get; set; }

        public string JeSourceNo { get; set; }

        public List<GlJeLinesDetailsVM> GlJeLinesDetailsVM { get; set; }

        public bool ValidActionAfterPostStatus { get; set; }
    }
}
