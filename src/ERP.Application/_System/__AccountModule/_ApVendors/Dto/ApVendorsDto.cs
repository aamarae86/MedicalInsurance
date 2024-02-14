using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApVendors;
using ERP._System._FndLookupValues.Dto;

namespace ERP._System.__AccountModule._ApVendors.Dto
{
    [AutoMap(typeof(ApVendors))]
    public class ApVendorsDto : AuditedEntityDto<long>
    {
        public string VendorNumber { get; set; }

        public string VendorNameAr { get; set; }

        public string VendorNameEn { get; set; }

        public long StatusLkpId { get; set; }

        public long VendorCategoryLkpId { get; set; }

        public string Comments { get; set; }

        public string Address { get; set; }

        public string WorkTel { get; set; }

        public string Mobile { get; set; }

        public string Fax { get; set; }

        public string TaxNo { get; set; }

        public string Email { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndVendorCategoryLkp { get; set; }
    }
}
