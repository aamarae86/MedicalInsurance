using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._modules;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._Modules.Dto
{
    [AutoMap(typeof(Page))]
    public class PagesDto : EntityDto
    {
        [MaxLength(100)]
        public string NameAr { get; set; }

        [MaxLength(100)]
        public string NameEn { get; set; }

        [MaxLength(100)]
        public string Selector { get; set; }

        [MaxLength(100)]
        public string Link { get; set; }

        [MaxLength(100)]
        public string Icon { get; set; }

        public int ModuleId { get; set; }

        [MaxLength(200)]
        public string VideoUrlAr { get; set; }

        [MaxLength(200)]
        public string VideoUrlEn { get; set; }

        [MaxLength(200)]
        public string DocPathAr { get; set; }

        [MaxLength(200)]
        public string DocPathEn { get; set; }

        public string ModuleAr { get; set; }

        public string ModuleEn { get; set; }
    }
}
