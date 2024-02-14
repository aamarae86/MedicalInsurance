using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptScPortalRequestStudyScreenData
    {
        public long Id { get; set; }
        public string ResearcherName { get; set; }
        public decimal MonthlyIncomeAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public string StudyNumber { get; set; }
        public DateTime StudyDate { get; set; }
        public string IdNumber { get; set; }
        public string UserName { get; set; }
        public string StudyType { get; set; }
        public string StudyDetails { get; set; }
        public string ResearcherDecision { get; set; }
        public decimal Remained { get; set; }
    }
}