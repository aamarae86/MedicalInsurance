using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto
{
    [AutoMap(typeof(TmCharityBoxCollectMembers))]
    public class TmCharityBoxCollectMembersDto : AuditedEntityDto<long>
    {
        public string MemberNumber { get; set; }

        [Required]
        public string MemberName { get; set; }

        public long MemberCategoryLkpId { get; set; }

        public FndLookupValuesDto FndMemberCategoryValues { get; set; }

        public bool IsActive { get; set; }
    }
}
