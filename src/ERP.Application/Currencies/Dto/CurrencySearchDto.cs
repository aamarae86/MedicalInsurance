using Abp.AutoMapper;

namespace ERP.Currencies.Dto
{
    [AutoMapFrom(typeof(Currency))]
    public class CurrencySearchDto
    {
        public string Code { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public override string ToString()
        {
            return $"Params.Code={Code}&Params.DescriptionAr={DescriptionAr}&Params.DescriptionEn={DescriptionEn}";
        }
    }
}
