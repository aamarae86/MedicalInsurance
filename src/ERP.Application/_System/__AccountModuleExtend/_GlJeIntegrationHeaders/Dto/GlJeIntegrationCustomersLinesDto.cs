using Abp.AutoMapper;
using ERP._System._ArCustomers;

namespace ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders.Dto
{
    [AutoMap(typeof(GlJeIntegrationLines))]
    public class GlJeIntegrationCustomersLinesDto : GlJeIntegrationLinesBaseDto
    {
        public long? ArCustomerId { get; set; }


        public string CustomerNumber { get; set; }

        public string CustomerNameAr { get; set; }

        public string CustomerNameEn { get; set; }
    }
}
