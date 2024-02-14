using Abp.AutoMapper;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    [AutoMap(typeof(GlJeIntegrationLines))]
    public class GlJeIntegrationVendorsLinesDto : GlJeIntegrationLinesBaseDto
    {
        public long? ApVendorId { get; set; }

        public string VendorNumber { get; set; }

        public string VendorNameAr { get; set; }

        public string VendorNameEn { get; set; }
    }
}
