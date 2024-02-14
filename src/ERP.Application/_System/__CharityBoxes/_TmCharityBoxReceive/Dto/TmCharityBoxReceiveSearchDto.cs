using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto
{
    public class TmCharityBoxReceiveSearchDto
    {
        public string ReceiveDateFrom { get; set; }
        public string ReceiveDateTo { get; set; }

        public string ReceiveNumber { get; set; }

        public long? StatusLkpIdSearch { get; set; }

        public long? CharityTypeId { get; set; }

        public override string ToString()
        {
            return $"Params.ReceiveNumber={ReceiveNumber}&Params.StatusLkpIdSearch={StatusLkpIdSearch}&Params.CharityTypeId={CharityTypeId}&Params.ReceiveDateFrom={ReceiveDateFrom}&Params.ReceiveDateTo={ReceiveDateTo}";
        }
    }
}
