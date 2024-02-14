using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersonVacations.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersonVacations
{
    public interface IHrPersonVacationsAppService : IAsyncCrudAppService<HrPersonVacationsDto, long, HrPersonVacationsPagedDto, HrPersonVacationsCreateDto, HrPersonVacationsEditDto>
    {
        Task<HrPersonVacationsDto> GetDetailAsync(EntityDto<long> input);

        Task<PostOutput> PostHrPersonVacations(PostDto postDto);

        Task<decimal> GetVacationsBalance(long hrPersonId, long hrVacationsTypeId);

        Task<Select2PagedResult> GetHrVacationsTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
