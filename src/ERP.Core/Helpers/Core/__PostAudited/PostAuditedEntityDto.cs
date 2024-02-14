using Abp.Application.Services.Dto;
using System;

namespace ERP.Helpers.Core.__PostAudited
{
    public abstract class PostAuditedEntityDto<TPrimaryKey> : AuditedEntityDto<TPrimaryKey>, IPostAudited, IUnPostAudited
    {
        protected PostAuditedEntityDto() { }

        public long? PostUserId { get; set; }
        public DateTime? PostTime { get; set; }
        public long? UnPostUserId { get; set; }
        public DateTime? UnPostTime { get; set; }
    }
}
