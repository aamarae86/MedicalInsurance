using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    public class ApInvoiceHdSearchDto
    {
        public string VendorNo { get; set; }

        public string HdInvNo { get; set; }

        public string HdDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? VendorId { get; set; }

        public long? HdTypeLkpId { get; set; }

        public override string ToString() => $"Params.VendorNo={VendorNo}&Params.HdInvNo={HdInvNo}&Params.HdDate={HdDate}&Params.StatusLkpId={StatusLkpId}&Params.HdTypeLkpId={HdTypeLkpId}&Params.VendorId={VendorId}";

    }
}
