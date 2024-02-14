using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ArJobCardScreenDataOutput
    {
        public decimal OriginalAmount { get; set; }
        public string ClaimNo { get; set; }
        public string LpoNo { get; set; }
        public decimal ExcessAmount { get; set; }
        public decimal ExcessVatPercentage { get; set; }
        public decimal ExcessVatAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehiclePlateNo { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public string CustomerMobile { get; set; }

        public string JobDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}