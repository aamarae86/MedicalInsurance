using Abp.Application.Services.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArJobSurveyTr
{
    public class ArJobSurveyTrDto : AuditedEntityDto<long>, IDetailRowStatus
    {
        public long? ArJobSurveyHdId { get; set; }
        public long? ArJobSurveyPartsId { get; set; }
        public string SurveyPartsName { get;   set; }
        public long? PartsCategoryLkpId { get; set; }
        public string PartsCategoryName { get;   set; }
        public bool IsRepair { get; set; }
        public bool IsReplace { get; set; }
        public string rowStatus { get; set; }
       // public int TenantId { get; set; }
    }
}
