using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvItemsTypesConfigure.Dto
{
    [AutoMap(typeof(IvItemsTypesConfigure))]
    public class IvItemsTypesConfigureEditDto : EntityDto<long>
    {
        [Required]
        [MaxLength(200)]
        public string NameEn { get; set; }

        [Required]
        [MaxLength(200)]
        public string NameAr { get; set; }

        public string ConfigureCode { get; set; }

        public string ParentPath { get; set; }

        public long? ParentId { get; set; }
    }
}
