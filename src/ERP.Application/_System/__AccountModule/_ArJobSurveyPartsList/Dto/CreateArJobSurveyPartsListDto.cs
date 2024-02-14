using Abp.AutoMapper;
using ERP._System.__AccountModule._ArJobSurveyPartsList;

namespace ERP._System.__CharityBoxes._ArJobSurveyPartsList.Dto
{
    [AutoMap(typeof(ArJobSurveyPartsList))]
    public class CreateArJobSurveyPartsListDto
    {
        public string PartsNumber { get; set; }
        public string PartsName { get; set; }
        public long PartsCategoryLkpId { get; set; }
    }
}
