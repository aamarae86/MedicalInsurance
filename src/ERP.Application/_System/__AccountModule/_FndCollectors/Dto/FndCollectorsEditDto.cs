using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._FndCollectors.Dto
{
    [AutoMap(typeof(FndCollectors))]
    public class FndCollectorsEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string CollectorNameAr { get; set; }

        [MaxLength(200)]
        public string CollectorNameEn { get; set; }
    }
}
