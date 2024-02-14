using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptrptScPortalAidsPerNationalityOutput
    {
        public string NationalityName { get; set; }
        public decimal AidAmount { get; set; }
        public int NoRequests { get; set; }
    }
}