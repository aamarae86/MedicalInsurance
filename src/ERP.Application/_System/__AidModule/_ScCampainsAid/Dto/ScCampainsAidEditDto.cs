using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ERP._System._ScCampainsAid.Dto
{
    [AutoMap(typeof(ScCampainsAid))]
    public class ScCampainsAidEditDto : EntityDto<long>
    {
        public long CampainsAidCategoryLkpId { get; set; }

        public string AidName { get; set; }

        public decimal AidAmount { get; set; }

        public bool IsActive { get; set; }
    }
}
