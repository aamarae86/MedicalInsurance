using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    public class IvReceiveHdSearchDto
    {
        public string HdReceiveNumber { get; set; }

        public string HdReceiveDate { get; set; }

        public long? IvWarehouseId { get; set; }

        public long? VendorId { get; set; }

        public override string ToString()
            => $"Params.HdReceiveNumber={HdReceiveNumber}&Params.HdReceiveDate={HdReceiveDate}&Params.VendorId={VendorId}&Params.IvWarehouseId={IvWarehouseId}";

    }
}
