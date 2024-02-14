using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScDeliveryOtherAids.Dto
{
    public class ScDeliveryOtherAidsSearchDto
    {
        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? CommitteeId { get; set; }

        public override string ToString() => $"Params.OperationNumber={OperationNumber}&Params.OperationDate={OperationDate}&Params.StatusLkpId={StatusLkpId}&Params.CommitteeId={CommitteeId}";
    }
}
