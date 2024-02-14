using Abp.AutoMapper;
using System.Collections.Generic;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    [AutoMapTo(typeof(SpCases))]
    public class SpCasesCreateDto : SpCasesBaseDto
    {
        public string CaseNumber { get; set; }
    }
}
