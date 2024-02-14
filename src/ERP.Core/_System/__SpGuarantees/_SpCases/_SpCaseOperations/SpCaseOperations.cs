using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System._FndLookupValues;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpCases._SpCaseOperations
{
    public class SpCaseOperations : AuditedEntity<long>, IMustHaveTenant
    {
        public DateTime OperationDate { get; protected set; }

        public long ReasonLkpId { get; protected set; }

        public long OperationTypeLkpId { get; protected set; }

        public long SpContractDetailsId { get; protected set; }

        public long? SpNewContractDetailsId { get; protected set; }


        [ForeignKey(nameof(ReasonLkpId)), Column(Order = 0)]
        public FndLookupValues FndReasonLkp { get; protected set; }

        [ForeignKey(nameof(OperationTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndOperationTypeLkp { get; protected set; }

        [ForeignKey(nameof(SpContractDetailsId)), Column(Order = 0)]
        public SpContractDetails SpContractDetails { get; protected set; }

        [ForeignKey(nameof(SpNewContractDetailsId)), Column(Order = 1)]
        public SpContractDetails NewwSpContractDetails { get; protected set; }

        public int TenantId { get; set; }
    }
}
