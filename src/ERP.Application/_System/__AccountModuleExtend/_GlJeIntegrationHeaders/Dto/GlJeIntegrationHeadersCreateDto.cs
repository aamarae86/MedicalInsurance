using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    [AutoMap(typeof(GlJeIntegrationHeaders))]
    public class GlJeIntegrationHeadersCreateDto
    {
        [Required]
        [MaxLength(500)]
        public string JeName { get; set; }

        [MaxLength(100)]
        public string GlJeIntegrationNumber { get; set; }

        public string GlJeIntegrationDate { get; set; }

        public decimal CurrencyRate { get; set; }

        [MaxLength(4000)]
        public string GlJeIntegrationNotes { get; set; }

        [MaxLength(20)]
        public string GlJeIntegrationSourceNo { get; set; }

        public long PeriodId { get; set; }

        public int CurrencyId { get; set; }

        public long? StatusLkpId => 922;

        public long? GlJeIntegrationSourceId { get; set; }

        public virtual ICollection<GlJeIntegrationAccountsLinesDto> GlJeIntegrationAccountsLines { get; set; }

        public virtual ICollection<GlJeIntegrationVendorsLinesDto> GlJeIntegrationVendorsLines { get; set; }

        public virtual ICollection<GlJeIntegrationCustomersLinesDto> GlJeIntegrationCustomersLines { get; set; }
    }
}
