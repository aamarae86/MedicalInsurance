using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._GlAccDetails.Dto;
using ERP._System._GlAccDetails.Dto;
using ERP._System._GlAccHeaders.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._GlAccDetails
{
    public interface IGlAccDetailsAppService : IAsyncCrudAppService<GlAccDetailsDto, long, PagedGlAccDetailsResultRequestDto, CreateGlAccDetailsDto, GlAccDetailsEditDto>
    {
        Task<List<GlAccHeadersDto>> DrawGlAccController();

        Task<DefaulGlAccDetailsInfo> GetDefaultGlAccDetails(string lang = "ar-EG");

        Task<GlAccDetailsDetailDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetGlAccDetailsSelect2(long glheaderId, long? parentId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetGlAccHeaderDetailsSelect2(long glheaderId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<bool> NameExist(long? id, string nameAr, string nameEn);

        Task<bool> CodeExist(long? id, string code, long GlAccHeaderId, long? parentId);
    }
}
