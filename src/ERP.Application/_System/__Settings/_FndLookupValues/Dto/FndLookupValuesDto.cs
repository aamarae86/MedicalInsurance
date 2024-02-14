using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System._FndLookupValues.Dto
{
    [AutoMapFrom(typeof(FndLookupValues))]
    public class FndLookupValuesDto : AuditedEntityDto<long>
    {
        public string NameEn { get;  set; }

        public string NameAr { get;  set; }

        public string LookupCode { get;  set; }

        public string LookupType { get;  set; }

        public bool YesNo { get;  set; }

        public string AddedValues { get;  set; }
    }
}
