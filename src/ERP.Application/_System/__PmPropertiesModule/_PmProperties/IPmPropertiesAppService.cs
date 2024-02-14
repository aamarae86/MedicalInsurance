using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmProperties.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmProperties
{
    public interface IPmPropertiesAppService : IAsyncCrudAppService<PmPropertiesDto, long, PagedPmPropertiesRequestDto, CreatePmPropertiesDto, PmPropertiesEditDto>
    {
        Task<Select2PagedResult> GetPmPropertiesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPmPropertiesNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PmPropertiesDto> GetDetailAsync(EntityDto<long> input);

        Task<List<PmPropertiesUnitsDto>> GetAllPmPropertiesUnits(EntityDto<long> input);

        Task<List<PmPropertiesRevenueAccountsDto>> GetAllRevenues(EntityDto<long> input);

        Task<Select2PagedResult> GetUnitNumbersForContractsSelect2(long propertyId, long pmUnitTypeLkpId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<(string ownerName, string propertyNumber, long ownerId)> GetPmPropertiesInfo(EntityDto<long> input, string lang = "ar-EG");
    }
}
