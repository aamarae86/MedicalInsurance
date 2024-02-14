using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    public class CollectorVM : AuditedEntity<long>, IAuditedEntityStrDates
    {
        public int? CollectorNumber { get;  set; }
        public string CollectorNameAr { get;  set; }
        public string CollectorNameEn { get;  set; }

        public string CreationTimeStr => this.CreationTime.ToString("yyyy/MM/dd");
        //public string DeletionTimeStr => this.DeletionTime == null ? null : this.DeletionTime.Value.ToString("yyyy/MM/dd");
        public string LastModificationTimeStr => this.LastModificationTime == null ? null : this.LastModificationTime.Value.ToString("yyyy/MM/dd");
    }
}