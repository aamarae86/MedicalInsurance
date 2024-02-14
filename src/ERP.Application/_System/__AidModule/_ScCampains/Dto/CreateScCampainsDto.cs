using Abp.AutoMapper;
using ERP._System.__AidModule._ScCampainsDetail.Dto;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    [AutoMap(typeof(ScCampains))]
    public class CreateScCampainsDto
    {
        public string CampainNumber { get; set; }

        public string CampainName { get; set; }

        public string ScCampainDate { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ScCampainsStatues);

        public string Notes { get; set; }

        public List<ScCampainsDetailDto> ScCampainDetailsList { get; set; }
    }
}
