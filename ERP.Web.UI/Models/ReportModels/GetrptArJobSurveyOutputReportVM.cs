using ERP.ResourcePack.Common;
using ERP.Web.UI.Models.ViewModels.Accounts;
using ERP.Web.UI.Models.ViewModels.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Linq;

namespace ERP.Web.UI.Models.ReportModels
{
    public class GetrptArJobSurveyOutputReportVM
    {
        public string ClaimNo { get; set; }
        public string ClaimDate { get; set; }
        public bool InsuredVehicle { get; set; }
        public bool TPVehicle { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string PlateNo { get; set; }
        public string Comments { get; set; }
        public int TenantId { get; set; }
        public string PartsCategoryName { get; set; }
        public string PartsName { get; set; }   //1st 15 items
        public string PartsName1 { get; set; }  //next remaining items
        public bool IsRepair { get; set; }
        public bool IsReplace { get; set; }
        public string VehicleColor { get; set; }
        public decimal PartAmount { get; set; }
        public decimal LabourAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Days { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string VehicleConditionRepair { get; set; }
        public string VehicleConditionReplace { get; set; }
        public decimal LumpsumAmount { get; set; }
        public string AmountInWords { get; set; }

    }

    public class RptArJobSurveyOutputReportVM
    {

        public string ClaimNo { get; set; }
        public string ClaimDate { get; set; }
        public bool InsuredVehicle { get; set; }
        public bool TPVehicle { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string PlateNo { get; set; }
        public string Comments { get; set; }
        public int TenantId { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public decimal EstimatedAmount { get; set; }
        public decimal LabourCharges { get; set; }
        public decimal TotalAmount { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleEmirate { get; set; }
        public string JobType { get; set; }

        public string PartsName { get; set; }
        public string PartsCategoryName { get; set; }
        public bool IsRepair { get; set; }
        public bool IsReplace { get; set; }
    }
}