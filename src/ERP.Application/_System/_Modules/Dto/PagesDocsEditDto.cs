using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._modules;
using ERP._System._TenantFreeModules.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._Modules.Dto
{
    [AutoMap(typeof(Page))]
    public class PagesDocsEditDto : EntityDto
    {
        //[MaxLength(200)]
        //public string VideoUrlAr { get; set; }

        //[MaxLength(200)]
        //public string VideoUrlEn { get; set; }

        //[MaxLength(200)]
        //public string DocPathAr { get; set; }

        //[MaxLength(200)]
        //public string DocPathEn { get; set; }

        public string NameAr { get;   set; }

        public string NameEn { get;   set; }

        public string Selector { get;     set; }

        public string Link { get;   set; }

        public string Icon { get;   set; }

        public int ModuleId { get;   set; }
        public string VideoUrlAr { get;   set; }

        public string VideoUrlEn { get;   set; }

        public string DocPathAr { get;   set; }

        public string DocPathEn { get;   set; }
    }
}
