using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScCampainsDetail.Dto;
using System.Collections.Generic;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    [AutoMap(typeof(ScCampains))]
    public class ScCampainsEditDto : EntityDto<long>
    {
        public string CampainName { get; set; }

        public string ScCampainDate { get; set; }

        public string Notes { get; set; }

        public List<ScCampainsDetailDto> ScCampainDetailsList { get; set; }
    }
}
