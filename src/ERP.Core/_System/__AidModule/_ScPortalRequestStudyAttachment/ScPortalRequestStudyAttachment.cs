using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequestStudyAttachment
{
    public class ScPortalRequestStudyAttachment : AttachAuditedEntity, IMustHaveTenant
    {
        public long? PortalRequestStudyId { get;protected set; }
        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }
        public int TenantId { get; set; }

        [ForeignKey(nameof(PortalRequestStudyId))]
        public ScPortalRequestStudy ScPortalRequestStudy { get; protected set; }
    }
}
