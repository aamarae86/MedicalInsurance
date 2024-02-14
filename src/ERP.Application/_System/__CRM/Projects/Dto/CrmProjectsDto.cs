using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmProjects.Dto
{
    public class CrmProjectsDto : AuditedEntityDto<long>
    {
        public string ProjectDate { get; set; }
        [StringLength(200)]
        public string ProjectNameAr { get; set; }
        [StringLength(200)]
        public string ProjectNameEn { get; set; }
        [StringLength(4000)]
        public string ProjectAdressAr { get; set; }
        [StringLength(4000)]
        public string ProjectAdressEn { get; set; }
        [StringLength(4000)]
        public string ContentAr { get; set; }
        [StringLength(4000)]
        public string ContentEn { get; set; }
        [StringLength(500)]
        public string Filepath { get; set; }
    }
}
