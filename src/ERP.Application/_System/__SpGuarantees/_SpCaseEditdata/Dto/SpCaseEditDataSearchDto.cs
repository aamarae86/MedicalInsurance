using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpCaseEditData.Dto
{
    public class SpCaseEditDataSearchDto
    {
        public long? CaseId { get; set; }

        public long? BeneficentId { get; set; }

        public string BeneficentNumber { get; set; }

        public string CaseNumber { get; set; }
    }
}
