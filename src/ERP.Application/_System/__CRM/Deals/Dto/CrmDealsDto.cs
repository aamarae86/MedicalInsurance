using ERP._System.__PmPropertiesModule._FmContracts.Dto;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmDeals.Dto
{
    public class CrmDealsDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(Id.ToString());

        public string DealDate { get; set; }
        public string DealName { get; set; }

        public long DealTypeLkpId { get; set; }
        public string DealTypeLkpval { get; set; }

        [MaxLength(150)]
        public string NextStep { get; set; }

        public long LeadSourceLkpId { get; set; }
        public string LeadSourceLkpVal { get; set; }

        public long CrmLeadsPersonsId { get; set; }
        public string CrmLeadsPersonsVal { get; set; }

        public decimal Amount { get; set; }
        public string ClosingDate { get; set; }

        public long StageLkpID { get; set; }
        public string StageLkpVal { get; set; }

        public string Probability { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Company { get; set; }


    }
}
