using System;

namespace ERP.Web.UI.Models.ReportModels
{
    public class SpCaseOperationsDataListOutput
    {
        public string Name { get; set; }

        public string CaseName { get; set; }

        public string CaseNumber { get; set; }

        public string BeneficentName { get; set; }

        public string BeneficentNumber { get; set; }

        public string ReasonName { get; set; }

        public string NewCaseName { get; set; }

        public string NewCaseNumber { get; set; }

        public DateTime CreationTime { get; set; }
    }
}