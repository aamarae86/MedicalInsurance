using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd
{
    public interface IArInvoiceSettlementHdAppService : IAsyncCrudAppService<ArInvoiceSettlementHdDto, long, ArInvoiceSettlementHdPagedDto, ArInvoiceSettlementHdCreateDto, ArInvoiceSettlementHdEditDto>
    {
        Task<ArInvoiceSettlementHdDto> GetDetailAsync(EntityDto<long> input);
        Task<List<ArInvoiceSettlementCrDto>> GetAllArInvoiceSettlementCrs(long invoiceSettlementHdId , string lang);
        Task<List<ArInvoiceSettlementDrDto>> GetAllArInvoiceSettlementDrs(long invoiceSettlementHdId, string lang);
        Task<PostOutput> PostArInvoiceSettlement(PostDto input);
    }
}
