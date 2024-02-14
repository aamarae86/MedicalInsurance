using Abp.Domain.Entities;
using System;

namespace ERP._System.__SpGuarantees._SpCases._SpCaseEditData.ProcDto
{
    public class SpCaseEditDataInputDto : IMustHaveTenant
    {
        public string Lang { get; set; }

        public long SpContractDetailsId { get; set; }

        public long? BankLkpId { get; set; }
        public string AccountOwnerName { get; set; }
        public string AccountNumber { get; set; }
        public string SponsFor { get; set; }
        public string Amount { get; set; }
        public string Notes { get; set; }

        public long UserId { get; set; }

        public int TenantId { get; set; }
    }
}
