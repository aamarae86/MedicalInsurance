using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ERP._System.__SalesModule._IvSaleHd
{
    public interface IIvSaleHdAppService : IAsyncCrudAppService<IvSaleHdDto, long, IvSaleHdPagedDto, IvSaleHdCreateDto, IvSaleHdEditDto>
    {

        Task<IvSaleHdDto> GetDetailAsync(EntityDto<long> input);
        Task<PostRecords.Dto.PostOutput> PostHrSales(PostRecords.Dto.PostDto postDto);
        Task<List<SalesScreenDataOutput>> GetSalesScreenData(IdLangInputDto input);
        Task<Select2PagedResult> GetSalesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<string> GetPaymentMethodBySaleId(EntityDto<long> input);
        Task<bool> UpdateCreditRef(dynamic input);
        Task<bool> UpdateSalesMan(dynamic input);

    }
}
