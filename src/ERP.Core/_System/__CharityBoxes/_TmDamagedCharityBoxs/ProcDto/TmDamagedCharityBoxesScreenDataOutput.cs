using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs.ProcDto
{
    public class TmDamagedCharityBoxesScreenDataOutput
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
