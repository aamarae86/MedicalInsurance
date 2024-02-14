using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto
{
    [AutoMap(typeof(ArInvoiceSettlementCr))]
    public class ArInvoiceSettlementCrDto : EntityDto<long>, IDetailRowStatus
    {
        //SourceLkpId
        //CrSourceLkp
        //SourceId
        //CrSource
        //Amount
        //CrDate     
        public long ArInvoiceSettlementHdId { get; set; }
        public long ArInvoiceSettlementCrId { get; set; }
        public long SourceLkpId { get; set; }
        public long SourceId { get; set; }
        public decimal Amount { get; set; }
        public int TenantId { get; set; }

        public string CrSourceLkp { get; set; }
        public string CrSource { get; set; }
       // public double? CrAmount { get; set; }
        public string CrDate { get; set; }

        public string rowStatus { get; set; } = DetailRowStatus.RowStatus.NoAction.ToString();
    }
}
