using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArMiscReceipt._ArMiscReceiptHeaders.Dto;
using ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto;
using ERP._System._ArMiscReceiptHeaders.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArMiscReceipt._ArMiscReceiptHeaders
{
    public interface IArMiscReceiptHeadersAppService
        : IAsyncCrudAppService<ArMiscReceiptHeadersDto, long, PagedArMiscReceiptHeadersRequestDto, CreateArMiscReceiptHeadersDto, ArMiscReceiptHeadersEditDto>
    {
        Task<ArMiscReceiptHeadersDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ListArMiscReceiptDetailsVM>> GetAllArMiscReceiptDetails(long miscReceiptId);

        Task<List<ListArMiscReceiptLinesVM>> GetAllArMiscReceiptLines(long miscReceiptId);

        Task<PostOutput> PostArMiscReceiptHeader(PostDto input);

        Task<List<MiscReceiptScreenDataOutput>> GetMiscReceipttScreenData(IdLangInputDto input);

        Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSearchSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpCasesWithSpContractDetailsSelect2(long beneficentId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
