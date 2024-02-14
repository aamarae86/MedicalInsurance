using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._modules;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._Modules.Dto
{
    [AutoMap(typeof(Page))]
    public class PagesEditDto : EntityDto
    {
        [MaxLength(100)]
        public string NameAr { get; set; }

        [MaxLength(100)]
        public string NameEn { get; set; }

        [MaxLength(100)]
        public string Icon { get; set; }
    }
}
