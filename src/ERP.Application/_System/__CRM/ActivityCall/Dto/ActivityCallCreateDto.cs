using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._ActivityCall.Dto
{
    [AutoMap(typeof(ActivityCall))]
    public class ActivityCallCreateDto
    {
        public long RelatedToLkpId { get; set; }
        public long CrmLeadsPersonsId { get; set; }
        [MaxLength(200)]
        public string Subject { get; set; }
        public long CallPurposeLkpId { get; set; }
        public long CallTypeLkpId { get; set; }
        public long CallDetailsLkpId { get; set; }
        public long? CrmDealsId { get; set; }
  
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        public long CallResultLkpId { get; set; }

    }
}
