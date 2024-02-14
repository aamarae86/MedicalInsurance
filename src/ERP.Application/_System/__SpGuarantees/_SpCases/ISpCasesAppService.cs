using Abp.Application.Services;
using Abp.Domain.Entities;
using ERP._System.__SpGuarantees._SpCases.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCases
{
    public interface ISpCasesAppService : IAsyncCrudAppService<SpCasesDto, long, SpCasesPagedDto, SpCasesCreateDto, SpCasesEditDto>
    {
        Task<PostOutput> PostSpCases(PostDto postDto);

        Task<SpCases> GetSpCaseForContract(long id);

        Task<Select2PagedResult> GetSpCasesForContractsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpCasesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpCasesGrantedSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpCasesForReplaceNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetSpCasesForReplaceNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
