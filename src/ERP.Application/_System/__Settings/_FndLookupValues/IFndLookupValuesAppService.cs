using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._FndLookupValues
{
    public interface IFndLookupValuesAppService : IApplicationService
    {
        Task<ListResultDto<FndLookupValuesDto>> GetAll();

        Task<Select2PagedResult> GetFndLookupValuesExcludingIdsSelect2(string type, string ids, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetFndLookupValuesSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetAttributesFndLookupValuesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetFndLookupValuesCampainsDetailsSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
