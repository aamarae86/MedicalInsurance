using ERP.Helpers.Core;

namespace ERP.Helpers.Parameters
{
    public class GlJeLinesDetailsVM : CodeComUtility, IDetailRowStatus
    {
        public int index { get; set; }

        public long? glJeLineId { get; set; }

        public decimal debitAmount { get; set; }

        public decimal creditAmount { get; set; }

        public string Notes { get; set; }

        public string AccountNumber { get; set; }

        public string rowStatus { get; set; }
    }

}
