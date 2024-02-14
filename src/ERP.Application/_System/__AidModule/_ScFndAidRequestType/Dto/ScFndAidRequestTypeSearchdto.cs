using Abp.AutoMapper;

namespace ERP._System.__AidModule._ScFndAidRequestType.Dto
{
    [AutoMap(typeof(ScFndAidRequestType))]
    public class ScFndAidRequestTypeSearchDto
    {
        public long? AidRequestTypeLkpId { get; set; }

        public bool IsMaintenance { get; set; }

        public bool IsElectronics { get; set; }

        public bool IsAll { get; set; }

        public override string ToString() => $"Params.AidRequestTypeLkpId={AidRequestTypeLkpId}&Params.IsElectronics={IsElectronics}&Params.IsMaintenance={IsMaintenance}&Params.IsAll={IsAll}";
    }
}
