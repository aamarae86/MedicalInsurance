using Abp.Application.Services;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr
{
    public interface IFmMaintRequisitionsHdrAppService : IAsyncCrudAppService<FmMaintRequisitionsHdrDto, long, FmMaintRequisitionsHdrPagedDto, FmMaintRequisitionsHdrCreateDto, FmMaintRequisitionsHdrEditDto>
    {
        Task<Select2PagedResult> GetPmPropertiesUnitsByPmPropIdSelect2(long propertyId, string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
