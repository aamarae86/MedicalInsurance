using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto
{
    public class TmCharityBoxCollectSearchDto
    {
        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string CollectNumber { get; set; }

        public long? StatusLkpId { get; set; }

        public long? BankAccountId { get; set; }

        public override string ToString() => $"Params.CollectNumber={CollectNumber}&Params.ToDate={ToDate}&Params.FromDate={FromDate}&Params.BankAccountId={BankAccountId}&Params.StatusLkpId={StatusLkpId}";

    }
}
