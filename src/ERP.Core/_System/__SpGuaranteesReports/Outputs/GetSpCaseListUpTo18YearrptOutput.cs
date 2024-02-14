using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuaranteesReports.Outputs
{
    public class GetSpCaseListUpTo18YearrptOutput
    {
        public string CaseName { get; set; }
        public string CaseNumber { get; set; }
        public string BeneficentName { get; set; }
        public string BeneficentNumber { get; set; }
        public string SponsType { get; set; }
        public DateTime StartDate { get; set; }
        public int Age { get; set; }
        public decimal Amount { get; set; }
    }
}
