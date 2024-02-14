namespace ERP._System.__PmPropertiesModule._FmEngineers.Dto
{
    public class FmEngineersSearchDto
    {
        public string EngineerNumber { get; set; }

        public string EngineerName { get; set; }

        public string Mobile1 { get; set; }

        public long? StatusLkpId { get; set; }

        public override string ToString()
            => $"Params.EngineerNumber={EngineerNumber}&Params.EngineerName={EngineerName}&Params.Mobile1={Mobile1}&Params.StatusLkpId={StatusLkpId}";
    }
}
