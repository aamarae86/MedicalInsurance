using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobSurveyHd.Proc
{
    public class GetrptArJobSurveyOutput
    {
        public string ClaimNo { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool InsuredVehicle { get; set; }
        public bool TPVehicle { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string PlateNo { get; set; }
        public string Comments { get; set; }
        public int TenantId { get; set; }
        public string PartsCategoryName { get; set; }
        public string PartsName { get; set; }
        public bool IsRepair { get; set; }
        public bool IsReplace { get; set; }
        public decimal PartAmount { get; set; }
        public decimal LabourAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Days { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string VehicleColor { get; set; }
        public decimal LumpsumAmount { get; set; }
        public string AmountInWords { get; set; }
    }
}
