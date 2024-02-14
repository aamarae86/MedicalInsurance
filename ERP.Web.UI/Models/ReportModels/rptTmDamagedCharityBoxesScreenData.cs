using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptTmDamagedCharityBoxesScreenData
    {
        public long Id { get; set; }
        public string CharityBoxName { get; set; }
        public string CharityBoxBarcode { get; set; }
        public string NameAr { get; set; }
        public string SupervisorName { get; set; }
        public string DamageReason { get; set; }
        public DateTime DamagedCharityBoxsDate { get; set; }
        public string DamagedCharityBoxsNumber { get; set; }
        public string Notes { get; set; }
    }
}