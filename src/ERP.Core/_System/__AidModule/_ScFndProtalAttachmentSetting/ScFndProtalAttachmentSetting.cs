using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScFndAidRequestType;
using ERP._System.__AidModule._ScFndPortalIntervalSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting
{
    public class ScFndProtalAttachmentSetting : AuditedEntity<long>, IMustHaveTenant
    {
        #region Props
        [Required]
        [MaxLength(200)]
        public string AttachmentNameAr { get; protected set; }

        [MaxLength(200)]
        public string AttachmentNameEn { get; protected set; }


        public long RequestTypeId { get; protected set; }

        public int OrderBy { get; protected set; }

        public bool IsRequired { get; protected set; }
        public bool IsActive { get; protected set; }
        [MaxLength(4000)]
        public string Notes { get; protected set; }


        [ForeignKey(nameof(RequestTypeId))]
        public ScFndAidRequestType ScFndAidRequestType { get; protected set; }

        public int TenantId { get; set; } 
        #endregion
    }
}
