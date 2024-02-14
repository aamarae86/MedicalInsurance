using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmTenants;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmTenantsAttachments
{
    public class PmTenantsAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }
        
        //[Required]
        //[MaxLength(1000)]
        //public string FilePath { get; protected set; }
        
        [Required]
        public long PmTenantId { get; protected set; }

        [ForeignKey(nameof(PmTenantId))]
        public PmTenants PmTenants { get; protected set; }

        public int TenantId { get; set; }
    }
}
