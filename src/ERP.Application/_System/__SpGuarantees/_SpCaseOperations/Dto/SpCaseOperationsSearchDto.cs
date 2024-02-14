using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpCaseOperations.Dto
{
    public class SpCaseOperationsSearchDto
    {
        public long? CaseId { get; set; }

        public long? BeneficentId { get; set; }

        public string BeneficentNumber { get; set; }

        public string CaseNumber { get; set; }
    }
}
