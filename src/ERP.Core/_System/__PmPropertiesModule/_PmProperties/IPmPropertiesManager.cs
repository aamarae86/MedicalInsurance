using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmProperties
{
    public interface IPmPropertiesManager : IDomainService
    {
        Task<Select2PagedResult> GetPmPropertiesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPmPropertiesNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
       
        Task<Select2PagedResult> GetPmPropertiesUnitsByPmPropIdSelect2(long propertyId, string searchTerm, int pageSize, int pageNumber, string lang);
        
        Task<Select2PagedResult> GetUnitNumbersForContractsSelect2(long propertyId , long pmUnitTypeLkpId ,string searchTerm, int pageSize, int pageNumber, string lang);

        Task<(string ownerName, string propertyNumber, long ownerId)> GetPmPropertiesInfo(long propId, string lang = "ar-EG");
    }
}
