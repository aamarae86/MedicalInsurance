using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.Dto
{
    public class GlJeHeaderLinesDetailsDto: CodeComUtility
    {
        public long? GlJeLineId { get; set; }

        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }

        public int Index { get; set; }

   
    }
}
