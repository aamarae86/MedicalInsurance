using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArReceipts.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ArReceipts
{
    public interface IArReceiptsAppService : IAsyncCrudAppService<ArReceiptsDto, long, PagedArReceiptsResultRequestDto, ArReceiptsCreateDto, ArReceiptsEditDto>
    {

        //Task<Select2PagedResult> GetArReceiptsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<ArReceiptsDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostArReceipt(PostDto input);

        Task<List<receipttScreenDataOutput>> GetreceipttScreenData(IdLangInputDto input);
        Task<Select2PagedResult> GetArReceipts_ReceiptsOnAccount_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang);
    }
}
