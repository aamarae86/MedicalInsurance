using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System.__AidModule._ScFndAidRequestType.Dto
{
    [AutoMap(typeof(ScFndAidRequestType))]
    public class CreateScFndAidRequestTypeDto : EntityDto<long>
    {
        public long AidRequestTypeLkpId { get; set; }

        public bool IsMaintenance { get; set; }

        public bool IsElectronics { get; set; }
    }
}
