using Abp.Domain.Entities.Auditing;
using ERP.Front.Helpers.Core;
using ERP.ResourcePack.Common;
using ERP.ResourcePack.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ERP.Web.UI.Models.ViewModels.General;

namespace ERP.Web.UI.Models.ViewModels.Accounts
{
    //public class GlPeriodsDetails : AuditedEntity<long>, IAuditedEntityStrDates
    //{
    //    [Required]
    //    public string PeriodNameAr { get; set; }
    //    [Required]
    //    public string PeriodNameEn { get; set; }
    //    [Required]
    //    public string StartDate { get; set; }
    //    [Required]
    //    public string EndDate { get; set; }
    //    [Required]
    //    public string StatusLkp { get; set; }

    //    public string CreationTimeStr => this.CreationTime.ToShortDateString();
    //        //public string DeletionTimeStr => this.DeletionTime == null ? null : this.DeletionTime.Value.ToShortDateString();
    //    public string LastModificationTimeStr => this.LastModificationTime == null ? null : this.LastModificationTime.Value.ToShortDateString();
    //}
}