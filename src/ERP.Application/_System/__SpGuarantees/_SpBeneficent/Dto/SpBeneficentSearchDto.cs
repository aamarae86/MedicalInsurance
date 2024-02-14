using System;

namespace ERP._System.__SpGuarantees._SpBeneficent.Dto
{
    public class SpBeneficentSearchDto
    {
        public string BeneficentNumber { get; set; }

        public long? BeneficentId { get; set; }

        public long? CityLkpId { get; set; }

        public string Mobile { get; set; }

        public override string ToString()
        {
            return $"Params.BeneficentNumber={BeneficentNumber}&Params.BeneficentId={BeneficentId}&Params.CityLkpId={CityLkpId}&Params.Mobile={Mobile}";
        }
    }
}
