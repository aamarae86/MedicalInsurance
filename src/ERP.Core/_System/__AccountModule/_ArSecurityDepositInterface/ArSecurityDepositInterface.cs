using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArSecurityDepositInterface
{
    public class ArSecurityDepositInterface : AuditedEntity<long>, IMustHaveTenant
    {
        [MaxLength(30)]
        public string SecurityDepositInterfaceNumber { get; protected set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Amount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        public long? ArCustomerId { get; protected set; }

        public long? SourceCodeLkpId { get; protected set; }

        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(SourceCodeLkpId)), Column(Order = 1)]
        public FndLookupValues FndSourceCodeLkp { get; protected set; }

        public long? SourceId { get; protected set; }

        [MaxLength(20)]
        public string SourceNo { get; protected set; }

        public int TenantId { get; set; }
    }
}
