using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._IvReturnSaleHd.Dto
{
   public class IvReturnSaleHdSearchDto
    {
       
        public long IvSaleHdId { get; set; }
        public string IvReturnSaleNumber { get; set; }
        public long StatusLkpId { get; set; }
        public string IvReturnSaleDate { get; set; }
        public string Comments { get; set; }
        public int CurrencyId { get; set; }
        public override string ToString() => $"Params.IvReturnSaleNumber={IvReturnSaleNumber}&Params.StatusLkpId={StatusLkpId}&Params.IvSaleHdId={IvSaleHdId}&Params.IvReturnSaleDate={IvReturnSaleDate}&Params.CurrencyId={CurrencyId}";



    }
}
