using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__SpGuarantees._SpCaseHistory
{
    public class SpCaseHistory : AuditedEntity<long>, IMustHaveTenant
    {
        public long SpCaseId { get; protected set; }

        public long OperationTypeLkpId { get; protected set; }

        public long CaseStatusLkpId { get; protected set; }

        public long? BeneficentId { get; protected set; }

        public long? SourceCodeLkpId { get; protected set; }

        public long? SourceId { get; protected set; }

        [MaxLength(4000)]
        public string OperationNotes { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(SpCaseId))]
        public SpCases SpCases { get; protected set; }

        [ForeignKey(nameof(BeneficentId))]
        public SpBeneficent SpBeneficent { get; protected set; }

        [ForeignKey(nameof(OperationTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndOperationTypeLkp { get; protected set; }

        [ForeignKey(nameof(CaseStatusLkpId)), Column(Order = 1)]
        public FndLookupValues FndCaseStatusLkp { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 2)]
        public FndLookupValues FndSourceCodeLkp { get; protected set; }

    }
}
