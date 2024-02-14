
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._ActivityCall.Dto
{
    public class ActivityCallDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(Id.ToString());

        public long RelatedToLkpId { get; set; }
        public string RelatedToLkpVal { get; set; }

        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }


        public long? CrmDealsId { get; set; }
        public string CrmDealsVal { get; set; }

        [MaxLength(200)]
        public string Subject { get; set; }

        public long CallPurposeLkpId { get; set; }
        public string CallPurposeLkpVal { get; set; }

        public long CallTypeLkpId { get; set; }
        public string CallTypeLkpVal { get; set; }

        public long CallDetailsLkpId { get; set; }
        public string CallDetailsLkpVal { get; set; }

        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }

        public long CallResultLkpId { get; set; }
        public string CallResultLkpVal { get; set; }

    }
}
