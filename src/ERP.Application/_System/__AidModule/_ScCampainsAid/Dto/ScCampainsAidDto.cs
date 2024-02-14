using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._ScCampainsAid.Dto
{
    [AutoMapFrom(typeof(ScCampainsAid))]
    public class ScCampainsAidDto : AuditedEntityDto<long>
    {
        public long CampainsAidCategoryLkpId { get; set; }

        [MaxLength(200)]
        public string AidName { get; set; }

        public decimal AidAmount { get; set; }

        public bool IsActive { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }
    }
}
