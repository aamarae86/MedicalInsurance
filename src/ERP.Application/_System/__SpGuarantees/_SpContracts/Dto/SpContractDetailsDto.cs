using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP.Helpers.Core;
using System;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    [AutoMap(typeof(SpContractDetails))]
    public class SpContractDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long SpContractId { get; set; }

        public long SpCaseId { get; set; }

        public string SpCase { get; set; }

        public long CaseStatusLkpId { get; set; }

        public string CaseStatus { get; set; }

        public string sponsorCategory { get; set; }

        public string caseNumber { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public decimal? Amount { get; set; }

        public string SponsFor { get; set; }

        public long? SpBeneficentBankId { get; set; }

        public string SpBeneficentBank { get; set; }

        public long? BankLkpId { get; set; }

        public string BankLkp { get; set; }

        public string AccountNumber { get; set; }

        public string AccountOwnerName { get; set; }

        public string rowStatus { get; set; }
    }
}
