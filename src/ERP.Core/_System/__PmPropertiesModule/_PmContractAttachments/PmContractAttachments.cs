using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContractAttachments
{
    public class PmContractAttachments : AttachAuditedEntity, IMustHaveTenant
    {
        [Required]
        [MaxLength(200)]
        public string AttachmentName { get; protected set; }

        //[Required]
        //[MaxLength(1000)]
        //public string FilePath { get; protected set; }

        public long PmContractId { get; protected set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; protected set; }

        public int TenantId { get; set; }

    }
}
