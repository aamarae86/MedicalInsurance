using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    [AutoMap(typeof(ArInvoiceSettlementHd))]
    public class ArInvoiceSettlementHdDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string SettlementDate { get; set; }
        public long StatusLkpId { get; set; }
        public decimal SettlementAmount { get; set; }
        public string SettlementNumber { get; set; }
        public long ArCustomerId { get; set; }
        public string Description { get; set; }
        public int TenantId { get; set; }

        public ArCustomers ArCustomers { get;  set; }
        public FndLookupValues FndStatusLkp { get;  set; }

        public virtual ICollection<ArInvoiceSettlementCr> ArInvoiceSettlementCr { get; protected set; }
        public virtual ICollection<ArInvoiceSettlementDr> ArInvoiceSettlementDr { get; protected set; }
    }
}
