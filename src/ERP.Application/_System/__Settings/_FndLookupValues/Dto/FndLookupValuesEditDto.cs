using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System._FndLookupValues.Dto
{
    [AutoMap(typeof(FndLookupValues))]
    public class FndLookupValuesEditDto : EntityDto<long>
    {
        public string NameEn { get; set; }

        public string NameAr { get; set; }
    }
}
