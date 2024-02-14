using System;

namespace ERP.Front.Helpers.Parameters.GlJeHeaders
{
    public class GlJeHeadersParms
    {
        public string JeName { get; set; }
        public string JeNumber { get; set; }
        public string JeDate { get; set; }

        public int? CurrencyId { get; set; }
        public Nullable<long> StatusLkpId { get; set; }
        public Nullable<long> JeSourceLkpId { get; set; }

        public override string ToString()
        {
            return $"Params.JeName={JeName}&Params.JeNumber={JeNumber}&Params.JeDate={JeDate}&Params.CurrencyId={CurrencyId}&Params.StatusLkpId={StatusLkpId}&Params.JeSourceLkpId={JeSourceLkpId}";
        }
    }
}
