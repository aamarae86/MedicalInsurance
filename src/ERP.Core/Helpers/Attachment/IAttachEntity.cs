using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.Helpers.Core
{
    public interface IAttachEntity : IEntity<long>
    {
        [Required]
        [MaxLength(1000)]
        string FilePath { get; set; }
    }

    public  class AttachEntity : Entity<long>, IAttachEntity
    {
        public string FilePath { get; set; }
    }

    public  class AttachCreationAuditedEntity : CreationAuditedEntity<long>, IAttachEntity
    {
        public string FilePath { get; set; }
    }

    public  class AttachAuditedEntity : AuditedEntity<long>, IAttachEntity
    {
        public string FilePath { get; set; }
    }
}
