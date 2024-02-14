using ERP.Helpers.Core.__PostAudited;
using System;

namespace ERP.Web.UI.Controllers.Base
{
    public class BasePostAuditedVM<TPrimaryKey> : PostAuditedEntity<TPrimaryKey>, IAuditedStringDates
    {
        public string CreationTimeStr => this.CreationTime.ToString();

        public string LastModificationTimeStr => this.LastModificationTime?.ToString() ?? string.Empty;

        public string PostedTimeStr => this.PostTime?.ToString() ?? string.Empty;

        public string UnPostedTimeStr => this.UnPostTime?.ToString() ?? string.Empty;

       // public new DateTime? LastModificationTime { get; set; }
    }
}