using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArJobCardHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ArJobCardHd
{
    public interface IArJobCardHdAppService : IAsyncCrudAppService<ArJobCardHdDto, long, ArJobCardHdPagedDto, ArJobCardHdCreateDto, ArJobCardHdEditDto>
    {
        Task<ArJobCardHdDto> GetDetailAsync(EntityDto<long> input);
        Task<ArJobCardHdDto> SaveCreditNoteAsync(ArJobCardHdEditDto input);
        Task<PostOutput> PostArJobCard(PostDto input);
        Task CloseArJobCard(ArJobCardHdDto input);        
        string GetExcessInvoiceNo(EntityDto<long> input);
        string GetCustomerInvoiceNo(EntityDto<long> input);
        Task<PagedResultDto<ArJobCardHdDto>> GetCheckForVehiclePlateAndEmirate(string plateno, long emirate);
        Task<bool> GetCheckForClaimAndLpo(string claim, string lpo);
        Task<Select2PagedResult> GetArJobCardHdJobNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetArJobCardHdJobNumberByCustomerIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long customerId = 0);
        string CheckJobNumber(string jobNum);
        Task<List<ArJobCardScreenDataOutput>> GetArJobCardScreenData(EntityDto<long> input);
    }
}
