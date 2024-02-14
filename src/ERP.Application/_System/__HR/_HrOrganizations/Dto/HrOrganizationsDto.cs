using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrOrganizations.Dto
{
    [AutoMap(typeof(HrOrganizations))]
    public class HrOrganizationsDto : AuditedEntityDto<long>
    {
        [Required]
        [MaxLength(200)]
        public string OrganizationName { get; set; }

        [MaxLength(200)]
        public string ShortName { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long OrganizationTypeLkpId { get; set; }

        public string ParentPath { get; set; }

        public long? ParentId { get; set; }

        public HrOrganizationsDto Parent { get; set; }

        public FndLookupValuesDto FndOrganizationTypeLkp { get; set; }
    }
}
