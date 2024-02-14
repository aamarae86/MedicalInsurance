using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    [AutoMap(typeof(GlJeIntegrationHeaders))]
    public class GlJeIntegrationHeadersDto : PostAuditedEntityDto<long>
    {
        public string EncId => Core.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());

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

        public long? StatusLkpId { get; set; }

        public long? GlJeIntegrationSourceId { get; set; }

        public long? GlJeIntegrationSourceLkpId { get; set; }

        public CurrencyDto Currency { get; set; }

        public GlPeriodsDetailsDto GlPeriodsDetails { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndGlJeIntegrationSourceLkp { get; set; }

        public virtual ICollection<GlJeIntegrationAccountsLinesDto> GlJeIntegrationAccountsLines { get; set; }

        public virtual ICollection<GlJeIntegrationVendorsLinesDto> GlJeIntegrationVendorsLines { get; set; }

        public virtual ICollection<GlJeIntegrationCustomersLinesDto> GlJeIntegrationCustomersLines { get; set; }

    }
}
