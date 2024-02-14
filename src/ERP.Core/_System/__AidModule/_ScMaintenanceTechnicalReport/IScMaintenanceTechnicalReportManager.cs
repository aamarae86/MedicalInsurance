using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    public interface IScMaintenanceTechnicalReportManager : IDomainService
    {
        Task<Select2PagedResult> GetScMaintenanceTechnicalReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
