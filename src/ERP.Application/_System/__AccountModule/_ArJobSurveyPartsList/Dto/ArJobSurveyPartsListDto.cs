using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ArJobSurveyPartsList;
using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CharityBoxes._ArJobSurveyPartsList.Dto
{
    [AutoMap(typeof(ArJobSurveyPartsList))]
    public class ArJobSurveyPartsListDto : AuditedEntityDto<long>
    {

        [MaxLength(30)]
        public string PartsNumber { get; set; }
        public string PartsName { get; set; }
        public long PartsCategoryLkpId { get; set; }
        public FndLookupValuesDto PartsCategoryLkp { get; set; }
    }
}
