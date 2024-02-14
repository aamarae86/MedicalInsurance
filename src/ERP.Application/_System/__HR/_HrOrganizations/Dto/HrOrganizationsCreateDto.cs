using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__HR._HrOrganizations.Dto
{
    [AutoMap(typeof(HrOrganizations))]
    public class HrOrganizationsCreateDto
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

    }
}
