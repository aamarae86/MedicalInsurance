using Abp.Application.Services.Dto;

namespace ERP._System.__PmPropertiesModule._PmOwners.Dto
{
    public class PmOwnersSearchDto : EntityDto<long>
    {
        public string HomePhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public long? StatusLkpId { get; set; }
        public long? CityLkpId { get; set; }
        public long? NationalityLkpId { get; set; }

        public override string ToString()
        {
            return $"Params.Id={Id}&Params.HomePhoneNumber={HomePhoneNumber}&Params.IdNumber={IdNumber}&Params.StatusLkpId={StatusLkpId}&Params.CityLkpId={CityLkpId}&Params.NationalityLkpId={NationalityLkpId}";
        }
    }
}
