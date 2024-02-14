using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System.__PmPropertiesModule._PmContract.Dto;
using ERP._System.__PmPropertiesModule._PmContract.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__PmContractModule._PmContract
{
    public interface IPmContractAppService : IAsyncCrudAppService<PmContractDto, long, PagedPmContractResultRequestDto, CreatePmContractDto, PmContractEditDto>
    {
        Task<PmContractDto> GetDetailAsync(EntityDto<long> input);
        Task<Select2PagedResult> GetPmContractSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<ModelForAjaxCall> GetPmContractForAjaxCall(long id);

        Task<PostOutput> PostContract(PostDto postDto);

        Task<PostOutput> RenewContract(PostDto postDto);

        Task<PostOutput> CancelContract(PostDto postDto);

        Task<PostOutput> ExpireContract(PostDto postDto);

        Task<List<GeContractScreenDataOutput>> GetContractScreenData(IdLangInputDto input);
    }
}
