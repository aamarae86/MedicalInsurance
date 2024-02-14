using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpCases;
using ERP.Helpers.Core;
using System;

namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    [AutoMap(typeof(SpCases))]
    public class SpFamilyCasesDto : EntityDto<long>, IDetailRowStatus
    {
        public string CaseName { get; set; }

        public string CaseNumber { get; set; }

        public string BirthDate { get; set; }

        public long SpFamilyId { get; set; }

        public long? RelativesTypeLkpId { get; set; }

        public long? SponsorCategoryLkpId { get; set; }

        public string SponsorCategoryLkp { get; set; }

        public long StatusLkpId { get; set; }

        public string RelativesTypeLkp { get; set; }

        public string rowStatus { get; set; }
    }
}
