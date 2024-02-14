using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto
{
    [AutoMap(typeof(TmCharityBoxCollectMembers))]
    public class TmCharityBoxCollectMembersCreateDto
    {
        [Required]
        public string MemberName { get; set; }

        public string MemberNumber { get; set; }

        public long MemberCategoryLkpId { get; set; }

        public bool IsActive { get; set; }
    }
}
