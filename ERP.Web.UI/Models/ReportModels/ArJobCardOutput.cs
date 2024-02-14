using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ArJobCardOutput
    {
		public string JobNumber { get; set; }
		public DateTime JobDate { get; set; }
		public string CustomerNameAr { get; set; }
		public string CustomerNameEn { get; set; }

		public long ArCustomerId { get; set; }
		public decimal EstimatedAmount { get; set; }
		public decimal OriginalAmount { get; set; }
		public decimal ExcessAmount { get; set; }

		public decimal Cost { get; set; }
		public decimal NetAmount { get; set; }
		public string Status { get; set; }
		public long FndSalesMenId { get; set; }

		public string SalesManNameAr { get; set; }
		public string SalesManNameEn { get; set; }
	}
}