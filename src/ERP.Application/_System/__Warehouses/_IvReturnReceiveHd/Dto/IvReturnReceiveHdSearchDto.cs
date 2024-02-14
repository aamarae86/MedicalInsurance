using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
   public class IvReturnReceiveHdSearchDto
    {

        
        public long IvReceiveHdId { get; set; }
        public string IvReturnReceiveNumber { get; set; }
        public long StatusLkpId { get; set; }
        public string IvReturnReceiveDate { get; set; }
        public string Comments { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyRate { get; set; }

        public override string ToString() => $"Params.IvReturnReceiveNumber={IvReturnReceiveNumber}&Params.StatusLkpId={StatusLkpId}&Params.IvReceiveHdId={IvReceiveHdId}&Params.IvReturnReceiveDate={IvReturnReceiveDate}&Params.CurrencyId={CurrencyId}";

    }
}
