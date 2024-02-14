using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonTimeSheetVM : BaseAuditedEntityVM<long>
    {
        [Display(Name = nameof(HrPersonTimeSheet.TimeSheetNumber), ResourceType = typeof(HrPersonTimeSheet))]
        public string TimeSheetNumber { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.ProjectName), ResourceType = typeof(HrPersonTimeSheet))]
        public string ProjectName { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.HrPersonId), ResourceType = typeof(HrPersonTimeSheet))]
        public long HrPersonId { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.TimeSheetTypeId), ResourceType = typeof(HrPersonTimeSheet))]
        public long TimeSheetTypeId { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.TimeSheetDate), ResourceType = typeof(HrPersonTimeSheet))]
        public string TimeSheetDate { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.FromTime), ResourceType = typeof(HrPersonTimeSheet))]
        public decimal FromTime { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.EndTime), ResourceType = typeof(HrPersonTimeSheet))]
        public decimal EndTime { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.FromTime), ResourceType = typeof(HrPersonTimeSheet))]
        public string FromTimeStr { get; set; }
        [Display(Name = nameof(HrPersonTimeSheet.EndTime), ResourceType = typeof(HrPersonTimeSheet))]
        public string EndTimeStr { get; set; }

        [Display(Name = nameof(HrPersonTimeSheet.Notes), ResourceType = typeof(HrPersonTimeSheet))]
        public string Notes { get; set; }
        public HrPersonsVM HrPersons { get; set; }
        public TimeSheetTypeVM TimeSheetType { get; set; }






    }
}