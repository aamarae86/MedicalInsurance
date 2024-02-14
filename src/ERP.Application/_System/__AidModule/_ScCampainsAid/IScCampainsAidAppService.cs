using Abp.Application.Services;
using ERP._System._ScCampainsAid.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._ScCampainsAid
{
    public interface IScCampainsAidAppService : IAsyncCrudAppService<ScCampainsAidDto, long, PagedScCampainsAidResultRequestDto, CreateScCampainsAidDto, ScCampainsAidEditDto>
    {
        Task<Select2PagedResult> GetScCampainsAidSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
