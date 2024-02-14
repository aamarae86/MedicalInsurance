using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using ERP._System.__SpGuarantees._SpCases.Dto;
using ERP._System._FndLookupValues.Dto;
using System;

namespace ERP._System.__SpGuarantees._SpCaseHistory.Dto
{
    [AutoMap(typeof(SpCaseHistory))]
    public class SpCaseHistoryDto : AuditedEntityDto<long>
    {
        public string Creator { get; set; }


        public long SpCaseId { get; set; }

        public long OperationTypeLkpId { get; set; }

        public long CaseStatusLkpId { get; set; }

        public long? BeneficentId { get; set; }

        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public string OperationNotes { get; set; }

        public SpCasesDto SpCases { get; set; }

        public SpBeneficentDto SpBeneficent { get; set; }

        public FndLookupValuesDto FndCaseStatusLkp { get; set; }

        public FndLookupValuesDto FndOperationTypeLkp { get; set; }

    }
}
