using Abp.Application.Services;
using ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers
{
    public interface ITmCharityBoxCollectMembersAppService : IAsyncCrudAppService<TmCharityBoxCollectMembersDto, long, PagedTmCharityBoxCollectMembersResultRequestDto, TmCharityBoxCollectMembersCreateDto, TmCharityBoxCollectMembersEditDto>
    {
        Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<TmCharityBoxCollectMembersDto> GetDetailAsync(Abp.Application.Services.Dto.EntityDto<long> input);
    }
}
