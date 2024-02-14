using Abp.Domain.Entities;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardHd
{
    public class ArJobCardAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [MaxLength(200)]
        public string AttachmentName { get;  set; }

        [Required]
        [MaxLength]
        public string FilePath { get;  set; }

        public long ArJobCardHdId { get;  set; }

        [ForeignKey(nameof(ArJobCardHdId))]
        public ArJobCardHd ArJobCardHd { get;  set; }
        public int TenantId { get;  set; }
        public long? TenxMigrationId { get; set; }

    }
}
