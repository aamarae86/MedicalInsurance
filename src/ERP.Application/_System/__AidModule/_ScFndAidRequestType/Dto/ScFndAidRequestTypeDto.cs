using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;

namespace ERP._System.__AidModule._ScFndAidRequestType.Dto
{
    [AutoMap(typeof(ScFndAidRequestType))]
    public class ScFndAidRequestTypeDto : AuditedEntityDto<long>
    {
        public long AidRequestTypeLkpId { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public bool ExistBefore { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public bool IsMaintenance { get; set; }

        public bool IsElectronics { get; set; }

        public bool IsAll { get; set; }
    }

}
