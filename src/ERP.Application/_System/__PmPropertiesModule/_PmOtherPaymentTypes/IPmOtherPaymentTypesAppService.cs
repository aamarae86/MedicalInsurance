using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__PmPropertiesModule._PmOtherPaymentTypes.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmOtherPaymentTypes
{
    public interface IPmOtherPaymentTypesAppService : IAsyncCrudAppService<PmOtherPaymentTypesDto, long, PagedPmOtherPaymentTypesResultRequestDto, CreatePmOtherPaymentTypesDto, PmOtherPaymentTypesEditDto>
    {
        Task<PmOtherPaymentTypesDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetPmOtherPaymentTypesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
