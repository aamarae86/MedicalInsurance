using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrOrganizations
{
    public interface IHrOrganizationsManager : IDomainService
    {
        Task<Select2PagedResult> GetHrOrganizationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetHrOrganizationsWithParentSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
