using Abp.Application.Services.Dto;
using System;

namespace ERP._System.__SpGuarantees._SpCases.Dto
{
    public class SpCasesSearchDto
    {
        public long? SpCaseId { get; set; }
        public string CaseNumber { get; set; }
        public string RegistrationDate { get; set; }
        public long? StatusLkpId { get; set; }
        public long? SpFamilyId { get; set; }
        public long? SponsorCategoryLkpId { get; set; }
        public long? NationallityLkpId { get; set; }
        public string FamilyNumber { get; set; }
        public long? SpBeneficentId { get; set; }

        public override string ToString()
        {
            return $"Params.SpCaseId={SpCaseId}&Params.SpBeneficentId={SpBeneficentId}&Params.CaseNumber={CaseNumber}&Params.RegistrationDate={RegistrationDate}&Params.StatusLkpId={StatusLkpId}&Params.SpFamilyId={SpFamilyId}&Params.SponsorCategoryLkpId={SponsorCategoryLkpId}&Params.NationallityLkpId={NationallityLkpId}&Params.FamilyNumber={FamilyNumber}";
        }
    }
}
