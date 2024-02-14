using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Helpers.Core.__PostAudited
{
    public abstract class PostAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IPostAudited, IUnPostAudited
    {
        protected PostAuditedEntity() { }

        public virtual long? PostUserId { get; set; }
        public virtual DateTime? PostTime { get; set; }
        public virtual long? UnPostUserId { get; set; }
        public virtual DateTime? UnPostTime { get; set; }

    
    }
}
