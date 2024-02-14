using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvItems.Dto
{
    public class IvItemsSearchDto
    {
        public long? IvItemsTypesConfigureId { get;  set; }
        public long? IvUnitId { get;  set; }
        public string IvItemNumber { get; set; }
        public string IvItemName { get; set; }
        public string IvItemBarcode { get; set; }
        public override string ToString() => $"Params.IvItemsTypesConfigureId={IvItemsTypesConfigureId}&Params.IvUnitId={IvUnitId}&Params.IvItemNumber={IvItemNumber}&Params.IvItemName={IvItemName}&Params.IvItemBarcode={IvItemBarcode}";
    }
}
