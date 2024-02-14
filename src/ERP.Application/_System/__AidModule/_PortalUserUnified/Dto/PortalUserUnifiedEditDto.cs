using Abp.AutoMapper;
using ERP.Authorization.Users;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._PortalUserUnified.Dto
{
    [AutoMap(typeof(PortalUser))]
    public class PortalUserUnifiedEditDto : PortalUserUnifiedEditBaseDto
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string IdNumber { get; set; }

        public long NationalityLkpId { get; set; }

        [MaxLength(200)]
        public string WifeHusbandName1 { get; set; }

        [MaxLength(50)]
        public string IdNumberWifeHusband1 { get; set; }

        [MaxLength(200)]
        public string JobWifeHusband1 { get; set; }

        [MaxLength(200)]
        public string WifeName2 { get; set; }

        [MaxLength(50)]
        public string IdNumberWife2 { get; set; }

        [MaxLength(200)]
        public string WifeName3 { get; set; }

        [MaxLength(50)]
        public string IdNumberWife3 { get; set; }

        [MaxLength(200)]
        public string WifeName4 { get; set; }

        [MaxLength(50)]
        public string IdNumberWife4 { get; set; }

        [MaxLength(200)]
        public string JobWife2 { get; set; }

        [MaxLength(200)]
        public string JobWife3 { get; set; }

        [MaxLength(200)]
        public string JobWife4 { get; set; }
    }
}
