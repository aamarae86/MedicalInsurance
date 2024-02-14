using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvPriceListHd.Dto
{
   public class IvPriceListHdSearchDto
    {
        public string PriceListNumber { get; set; }

        public string PriceListName  { get; set; }
        public override string ToString() => $"Params.PriceListNumber={PriceListNumber}&Params.PriceListName={PriceListName}";
    }
}
