using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxes.Dto
{
    public class TmCharityBoxesSearchDto
    {
        public string CharityBoxName { get; set; }
        public string CharityBoxBarcode { get; set; }

        public long? StatusLkpIdSearch { get; set; }

        public long? CharityTypeId { get; set; }

        public override string ToString()
        {
            return $"Params.CharityBoxName={CharityBoxName}&Params.CharityBoxBarcode={CharityBoxBarcode}&Params.StatusLkpIdSearch={StatusLkpIdSearch}&Params.CharityTypeId={CharityTypeId}";
        }
    }
}
