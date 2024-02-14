using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArInvoiceHd.Dto;
using ERP._System._ArInvoiceHd.Dto;
using ERP._System._ArInvoiceTr.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArInvoiceHd
{
    public interface IArInvoiceHdAppService : IAsyncCrudAppService<ArInvoiceHdDto, long, PagedArInvoiceHdResultRequestDto, CreateArInvoiceHdDto, ArInvoiceHdEditDto>
    {
        Task<ArInvoiceHdDto> GetDetailAsync(EntityDto<long> input);
        Task<ArInvoiceHdDto> GetDetailBySourceId(EntityDto<long> input);
        Task<List<ArInvoiceTrDto>> GetAllArInvoiceHdDetails(long gljeheaderId);
        Task<PostOutput> PostArInvoice(PostDto input);
        Task<Select2PagedResult> GetArInvoiceHd_ArInvoiceTr_NumSelect2(string searchTerm, long ArCustomerId, int pageSize, int pageNumber, string lang);
    }
}
