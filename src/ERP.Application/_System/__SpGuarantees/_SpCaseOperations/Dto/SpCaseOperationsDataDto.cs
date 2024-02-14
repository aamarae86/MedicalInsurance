using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpCaseOperations.Dto
{
    public class SpCaseOperationsDataDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string ContractNumber { get; set; }

        public string BeneficentName { get; set; }

        public string BeneficentNumber { get; set; }

        public string CaseDate { get; set; }

        public string ContractDate { get; set; }

        public string CaseNumber { get; set; }

        public string CaseName { get; set; }

        public string SponsorLkpNameAr { get; set; }

        public string SponsorLkpNameEn { get; set; }

        public long CaseId { get; set; }

    }
}
