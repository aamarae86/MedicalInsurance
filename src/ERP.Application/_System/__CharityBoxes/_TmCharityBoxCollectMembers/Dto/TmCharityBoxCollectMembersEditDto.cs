using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto
{
    [AutoMap(typeof(TmCharityBoxCollectMembers))]
    public class TmCharityBoxCollectMembersEditDto : EntityDto<long>
    {
        [Required]
        public string MemberName { get; set; }

        public long MemberCategoryLkpId { get; set; }

        public bool IsActive { get; set; }
    }
}
