using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    [AutoMap(typeof(ArInvoiceSettlementDr))]
    public class ArInvoiceSettlementDrDto : EntityDto<long>, IDetailRowStatus
    {
        //SourceLkpId
        //DrSourceLkp
        //SourceId
        //DrSource
        //Amount
        //DrDate
        //DrJobCard
        public long ArInvoiceSettlementHdId { get; set; }
        public long ArInvoiceSettlementDrId { get; set; }
        public long SourceLkpId { get; set; }
        public long SourceId { get; set; }
        public decimal Amount { get; set; }
        public int TenantId { get; set; }

        public string DrSourceLkp { get; set; }
        public string DrSource { get; set; }
       // public double? DrAmount { get; set; }
        public string DrDate { get; set; }
        public string DrJobCard { get; set; }

        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }
}
