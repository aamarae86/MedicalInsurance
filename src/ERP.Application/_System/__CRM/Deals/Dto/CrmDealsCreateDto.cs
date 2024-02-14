using Abp.AutoMapper;
using ERP._System.__CRM.Deals;
using ERP._System.__CRM.Deals.Dto;
using ERP._System.__CRM.Leads;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__CRM._CrmDeals.Dto
{
    [AutoMap(typeof(CrmDeals))]
    public class CrmDealsCreateDto
    {
        public string DealDate { get; set; }
        public string DealName { get; set; }
        public long DealTypeLkpId { get; set; }
        [MaxLength(150)]
        public string NextStep { get; set; }
        public long LeadSourceLkpId { get; set; }
        public long CrmLeadsPersonsId { get; set; }
        public decimal Amount { get; set; }
        public string ClosingDate { get; set; }
        public long StageLkpID { get; set; }
        public string Probability { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Company { get; set; }

        public ICollection<CrmDealsAttachmentsDto> Attachments { get; set; }
    }
}
