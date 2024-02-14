using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ArJobCardDetailsOutput
    {
		public string JobNumber { get; set; }
		public DateTime JobDate { get; set; }
		public string CustomerNameAr { get; set; }
		public string CustomerNameEn { get; set; }

		public long ArCustomerId { get; set; }
		public decimal EstimatedAmount { get; set; }
		public decimal OriginalAmount { get; set; }
		public decimal ExcessAmount { get; set; }

	
		public string Status { get; set; }
		public long FndSalesMenId { get; set; }

		public string SalesManNameAr { get; set; }
		public string SalesManNameEn { get; set; }

		public long VehicleMakeLkpId { get; set; }
		public string VehicleMakeAr { get; set; }
		public string VehicleMakeEn { get; set; }

		public long VehicleModelLkpId { get; set; }
		public string VehicleModelAr { get; set; }
		public string VehicleModelEn { get; set; }

		public string VehiclePlateNo { get; set; }

		public long VehicleColorLkpId { get; set; }
		public string VehicleColorAr { get; set; }
		public string VehicleColorEn { get; set; }

		public string PoliceReportNo { get; set; }
		public long PoliceReportSourceLkpId { get; set; }
		public string PoliceReportSourceAr { get; set; }
		public string PoliceReportSourceEn { get; set; }

		public string LpoNo { get; set; }
	}
}