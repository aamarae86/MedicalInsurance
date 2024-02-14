using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScCampainsDetail.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using System.Collections.Generic;

namespace ERP._System.__AidModule._ScCampains.Dto
{
    [AutoMap(typeof(ScCampains))]
    public class ScCampainsDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string CampainName { get; set; }

        public string CampainNumber { get; set; }

        public string ScCampainDate { get; set; }

        public long StatusLkpId { get; set; }

        public string Notes { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public List<ScCampainsDetailDto> ScCampainDetailsList { get; set; }
    }
}
