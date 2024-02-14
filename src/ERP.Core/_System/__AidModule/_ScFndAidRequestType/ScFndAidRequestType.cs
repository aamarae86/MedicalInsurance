using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting;
using ERP._System._FndLookupValues;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__AidModule._ScFndAidRequestType
{
    public class ScFndAidRequestType : AuditedEntity<long>, IMustHaveTenant
    {
        public long AidRequestTypeLkpId { get; protected set; }

        public bool IsMaintenance { get; protected set; }

        public bool IsElectronics { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(AidRequestTypeLkpId))]
        public virtual FndLookupValues FndLookupValues { get; protected set; }

        public virtual ICollection<ScFndProtalAttachmentSetting> ScFndProtalAttachmentSetting { get; protected set; }

        protected ScFndAidRequestType(long aidRequestTypeLkpId) => this.AidRequestTypeLkpId = aidRequestTypeLkpId;

        public static ScFndAidRequestType Create(long aidRequestTypeLkpId) => new ScFndAidRequestType(aidRequestTypeLkpId);
    }
}
