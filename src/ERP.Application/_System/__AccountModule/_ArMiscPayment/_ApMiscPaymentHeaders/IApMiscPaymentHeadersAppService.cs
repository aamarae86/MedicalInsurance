using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System._ApMiscPaymentHeaders.ProcDto;
using ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using ERP.Helpers.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArMiscPayment._ApMiscPaymentHeaders
{
    public interface IApMiscPaymentHeadersAppService : IAsyncCrudAppService<ApMiscPaymentHeadersDto, long, PagedArMiscPaymentHeadersRequestDto, CreateApMiscPaymentHeadersDto, ApMiscPaymentHeadersEditDto>
    {
        Task<ApMiscPaymentHeadersDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ListApMiscPaymentDetailsVM>> GetAllApMiscPaymentDetails(long miscPaymentId);

        Task<List<ListApMiscPaymentLinesVM>> GetAllApMiscPaymentLines(long miscPaymentId);

        Task<PostOutput> PostApMiscReceiptHeader(PostDto input);

        Task<List<MiscPaymentScreenDataOutput>> GetMiscPaymentScreenData(IdLangInputDto input);

        Task<Select2PagedResult> GetBeneficiaryNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
