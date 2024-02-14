using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModuleExtend._GlAccMapping.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._GlAccMapping
{
    public interface IGlAccMappingHdAppService : IAsyncCrudAppService<GlAccMappingHdDto, long, GlAccMappingHdPagedDto, GlAccMappingHdCreateDto, GlAccMappingHdEditDto>
    {
        Task<GlAccMappingHdDto> GetDetailAsync(EntityDto<long> input);

        Task<List<GlAccMappingTrDto>> GetAllGlAccMappingTr(EntityDto<long> input);

        Task<List<GlAccMappingTrDtlDto>> GetAllGlAccMappingTrDtl(EntityDto<long> input);

        Task<Select2PagedResult> GetGlAccMappingHdSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
