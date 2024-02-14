using Abp.Application.Services.Dto;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    public class PortalUserUnifiedEditBaseDto : PortalUserUnifiedCreateBaseDto, IEntityDto<long>
    {
        public long Id { get; set; }
    }
}
