using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    public interface IGlPeriodsYearsManager : IDomainService
    {
        Task<Select2PagedResult> GetGlPeriodsYearsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetGlPeriodsYearsReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
