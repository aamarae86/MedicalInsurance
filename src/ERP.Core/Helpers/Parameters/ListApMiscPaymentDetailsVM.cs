using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Helpers.Parameters
{
    public class ListApMiscPaymentDetailsVM: IDetailRowStatus
    {
        public int index { get; set; }
        public long? miscId { get; set; }
        public long? apMiscDetailId { get; set; }
        public string checkNumber { get;  set; }

        public string beneficiaryName { get;  set; }

        public decimal? amount { get;  set; }

        public string notes { get;  set; }

        public string maturityDate { get;  set; }

        public long? MiscPaymentId { get;  set; }
        public string rowStatus { get; set; }
    }
}
