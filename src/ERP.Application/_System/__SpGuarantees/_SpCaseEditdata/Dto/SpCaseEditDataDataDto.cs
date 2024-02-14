using Abp.Application.Services.Dto;
using ERP.Core.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpCaseEditData.Dto
{
    public class SpCaseEditDataDataDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string ContractNumber { get; set; }

        public string BeneficentName { get; set; }

        public string BeneficentNumber { get; set; }

        public string CaseDate { get; set; }

        public string StartDate { get; set; }

        public string ContractDate { get; set; }

        public string CaseNumber { get; set; }

        public string CaseName { get; set; }

        public string SponsorLkpNameAr { get; set; }

        public string SponsorLkpNameEn { get; set; }

        public long CaseId { get; set; }

        public long? BankLkpId { get; set; }
        public long BeneficentId { get; set; }
        public string BeneficentBankAr { get; set; }
        public string BeneficentBankEn { get; set; }
        public string AccountOwner { get; set; }
        public string AccountNumber { get; set; }
        public string NameFor { get; set; }
        public string Amount { get; set; }

        public long SpContractDetailsId { get; set; }
    }
}
