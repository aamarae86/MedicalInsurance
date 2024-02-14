using Abp.Application.Services.Dto;

namespace ERP._System.__PmPropertiesModule._PmTenants.Dto
{
    public class PmTenantsSearchDto : EntityDto<long>
    {
        public string HomePhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public long? CityLkpId { get; set; }
        public long? CountryLkpId { get; set; }
        public long? NationalityLkpId { get; set; }
        public string PassportNumber { get; set; }

        public override string ToString()
        {
            return $"Params.Id={Id}&Params.HomePhoneNumber={HomePhoneNumber}&Params.IdNumber={IdNumber}&Params.StatusLkpId={StatusLkpId}&Params.CountryLkpId={CountryLkpId}&Params.CityLkpId={CityLkpId}&Params.NationalityLkpId={NationalityLkpId}&Params.PassportNumber={PassportNumber}";
        }
    }
}
