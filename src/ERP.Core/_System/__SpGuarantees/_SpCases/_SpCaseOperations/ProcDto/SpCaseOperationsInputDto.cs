using Abp.Domain.Entities;
using System;

namespace ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto
{
    public class SpCaseOperationsInputDto : IMustHaveTenant
    {
        public string Ids { get; set; }

        public string Lang { get; set; }

        public string OperationDate { get; set; }

        public long ReasonLkpId { get; set; }

        public long OperationTypeLkpId { get; set; }

        public long UserId { get; set; }

        public int TenantId { get; set; }
    }

    public class SpCaseOperationsInputDto_Proc : IMustHaveTenant
    {
        public string Ids { get; set; }

        public string Lang { get; set; }

        public DateTime OperationDate { get; set; }

        public long ReasonLkpId { get; set; }

        public long OperationTypeLkpId { get; set; }

        public long UserId { get; set; }

        public int TenantId { get; set; }
    }
}
