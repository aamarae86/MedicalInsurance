using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace ERP.Web.UI.Controllers.Base
{
    public class BaseAuditedEntityVM<TPrimaryKey> : AuditedEntity<TPrimaryKey>
    {
        public string CreationTimeStr => this.CreationTime.ToString();

        public string LastModificationTimeStr => this.LastModificationTime?.ToString() ?? string.Empty;
    }
}