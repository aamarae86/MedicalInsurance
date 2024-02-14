using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectDetails
{
    public class TmCharityBoxCollectDetails : AuditedEntity<long>, IMustHaveTenant
    {
        public long TmCharityBoxCollectId { get; protected set; }

        public long CharityBoxActionDetailId { get; protected set; }

        [ForeignKey(nameof(CharityBoxActionDetailId))]
        public TmCharityBoxActionDetails TmCharityBoxActionDetails { get; protected set; }

        [ForeignKey(nameof(TmCharityBoxCollectId))]
        public TmCharityBoxCollect TmCharityBoxCollect { get; protected set; }

        public int TenantId { get; set; }
    }
}
