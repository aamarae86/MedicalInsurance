using Abp.Application.Services;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe
{
    public interface IFmMaintRequisitionsExeAppService : IAsyncCrudAppService<FmMaintRequisitionsExeDto, long, FmMaintRequisitionsExePagedDto, FmMaintRequisitionsExeCreateDto, FmMaintRequisitionsExeEditDto>
    {
        Task<Select2PagedResult> GetFmContractsVisitsNumberSelect2(long contactId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetFmEngineersNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
       
        Task<Select2PagedResult> GetFmMaintRequisitionsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetFmContractsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
