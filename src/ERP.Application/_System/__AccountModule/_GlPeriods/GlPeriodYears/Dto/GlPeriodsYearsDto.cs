using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._GlCodeComDetails;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._GlPeriods.Dto
{
    [AutoMap(typeof(GlPeriodsYears))]
    public class GlPeriodsYearsDto : AuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [Required]
        public string PeriodYear { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        [Required]
        public string AccountId { get; set; }

        [Required]
        public ICollection<GlPeriodsDetailsDto> GlPeriodsDetails { get; set; }

        public GlCodeComDetails GlCodeComDetails { get; set; }

        public string codeComUtilityTexts { get; set; }
        public string codeComUtilityIds { get; set; }
    }
}
