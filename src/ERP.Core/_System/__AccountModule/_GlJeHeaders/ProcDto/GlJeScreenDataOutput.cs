using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.ProcDto
{
   public class GlJeScreenDataOutput
    {
        public long id { get; set; }
        public string JeNumber { get; set; }
        public DateTime JeDate { get; set; }
        public string JeName { get; set; }
        public string JeNotes { get; set; }
        public string Source { get; set; }
        public string JeSourceNo { get; set; }
        public string Status { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public decimal Rate { get; set; }
        public string PeriodNameAr { get; set; }
        public string PeriodNameEn { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string LineNotes { get; set; }
        public decimal debitAmount { get; set; }
        public decimal CreditAmount { get; set; }
    }
}
