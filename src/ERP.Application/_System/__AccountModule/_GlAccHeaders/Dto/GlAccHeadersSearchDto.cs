using Abp.AutoMapper;

namespace ERP._System._GlAccHeaders.Dto
{
    [AutoMap(typeof(GlAccHeaders))]
    public class GlAccHeadersSearchDto
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
}
