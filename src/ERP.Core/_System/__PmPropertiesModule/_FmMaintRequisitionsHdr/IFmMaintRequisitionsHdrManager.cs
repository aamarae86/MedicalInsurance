using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr
{
    public interface IFmMaintRequisitionsHdrManager : IDomainService
    {
        Task<Select2PagedResult> GetFmMaintRequisitionsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
