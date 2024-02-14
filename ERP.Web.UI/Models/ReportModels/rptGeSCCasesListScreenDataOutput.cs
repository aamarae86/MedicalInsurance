using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Web.UI.Models.ReportModels
{
    public class rptGeSCCasesListScreenDataOutput
    {
        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        public string IdNumber { get; set; }
        public string NationalityName { get; set; }
        public string CityName { get; set; }
        public string MobileNumber { get; set; }
        public int FamilyCount { get; set; }
    }
}