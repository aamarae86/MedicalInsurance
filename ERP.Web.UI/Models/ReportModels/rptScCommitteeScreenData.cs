using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptScCommitteeScreenData
    {
        public long id { get; set; }
        public string CommitteeNumber { get; set; }
        public DateTime CommitteeDate { get; set; }
        public string CommitteeName { get; set; }
        public string PortalRequestNumber { get; set; }
        public string PortalUseName { get; set; }
        public string Nationality { get; set; }
        public string IdNumber { get; set; }
        public string Notes { get; set; }
        public int NoOfMonths { get; set; }
        public decimal AidAmount { get; set; }
    public string DStatues { get; set; }

    }
}