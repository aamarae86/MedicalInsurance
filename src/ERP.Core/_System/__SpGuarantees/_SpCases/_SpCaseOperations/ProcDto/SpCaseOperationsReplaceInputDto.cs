using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto
{
    public class SpCaseOperationsReplaceInputDto : IMustHaveTenant
    {
        public long NewCaseId { get; set; }

        public DateTime OperationDate { get; set; }

        public long SpContractDetailId { get; set; }

        public long ReasonLkpId { get; set; }

        public string Lang { get; set; }

        public long UserId { get; set; }

        public int TenantId { get; set; }
    }

    public class SpCaseOperationsReplaceInputDtoHelper : IMustHaveTenant
    {
        public long NewCaseId { get; set; }

        public string OperationDate { get; set; }

        public long SpContractDetailId { get; set; }

        public long ReasonLkpId { get; set; }

        public string Lang { get; set; }

        public long UserId { get; set; }

        public int TenantId { get; set; }
    }
}
