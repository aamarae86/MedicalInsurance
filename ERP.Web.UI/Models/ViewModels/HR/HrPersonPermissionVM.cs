using ERP.ResourcePack.HR;
using ERP.Web.UI.Controllers.Base;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ViewModels.HR
{
    public class HrPersonPermissionVM : BasePostAuditedVM<long>
    {

        [MaxLength(30)]
        [Display(Name = nameof(HrPersonPermission.OperationNumber), ResourceType = typeof(HrPersonPermission))]
        public string OperationNumber { get; set; }
        [Display(Name = nameof(HrPersonPermission.PermissionTypeId), ResourceType = typeof(HrPersonPermission))]
        public long PermissionTypeId { get; set; }
        [Display(Name = nameof(HrPersonPermission.PermissionDate), ResourceType = typeof(HrPersonPermission))]
        public string PermissionDate { get; set; }
        [Display(Name = nameof(HrPersonPermission.fromtime), ResourceType = typeof(HrPersonPermission))]
        public string FromTimeStr { get; set; }
        [Display(Name = nameof(HrPersonPermission.endtime), ResourceType = typeof(HrPersonPermission))]
        public string EndTimeStr { get; set; }
        public decimal FromTime { get; set; }
        public decimal EndTime { get; set; }
        [Display(Name = nameof(HrPersonPermission.total), ResourceType = typeof(HrPersonPermission))]
        public decimal TotalPermission { get; set; }

        public string permissionDetails { get; set; }
        [Display(Name = nameof(HrPersonPermission.HrPersonId), ResourceType = typeof(HrPersonPermission))]
        public long HrPersonId { get; set; }
        [Display(Name = nameof(HrPersonPermission.Notes), ResourceType = typeof(HrPersonPermission))]
        public string Notes { get; set; }

        public FndLookupValuesVM FndStatusLkp { get; set; }
        public HrPermissionTypeVM HrPermissionType { get; set; }

        public HrPersonsVM HrPersons { get; set; }



    }
}