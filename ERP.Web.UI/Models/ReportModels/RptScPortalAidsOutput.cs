using ERP.Helpers.Core;
using System;

namespace ERP.Web.UI.Models.ReportModels
{
    public class RptScPortalAidsOutput
    {
        public string NationalityName { get; set; }

        public string PortalUserName { get; set; }

        public string PortalRequestNumber { get; set; }

        public string RequestTypeName { get; set; }

        public DateTime ApDate { get; set; }

        public string MobileNumber1 { get; set; }

        public string CityName { get; set; }

        public string CashingTo { get; set; }

        public string ApNumber { get; set; }

        public int age { get; set; }

        public decimal ApAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PortalRequestDate { get; set; }

        public DateTime CommitteeDate { get; set; }

        public string CommitteeDateStr => this.CommitteeDate.ToString(Formatters.DateFormat) ;

        public string PortalRequestDateStr => this.PortalRequestDate.ToString(Formatters.DateFormat) ;
    }
}