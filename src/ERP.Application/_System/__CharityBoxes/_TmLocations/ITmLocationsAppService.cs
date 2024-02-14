using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._TmLocations.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmLocations
{
    public interface ITmLocationsAppService : IAsyncCrudAppService<TmLocationsDto, long, PagedTmLocationsResultRequestDto, CreateTmLocationsDto, TmLocationsEditDto>
    {

        Task<Select2PagedResult> GetSubLoactionForBoxesSelect2(long actionLkpId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<TmLocationsDto> GetDetailAsync(EntityDto<long> input);

        Task<bool> GetExistLocationNameAsync(string input, string Id);

        Task<bool> GetExistSubLocationNameAsync(string input, string Id);

        Task<Select2PagedResult> GetTmLocationSubSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetTmLocationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
