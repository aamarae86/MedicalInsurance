using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._Portal._PortalFndUsers
{
    public interface IPortalUnifiedUsersManager : IDomainService
    {
        Task<Select2PagedResult> GetUnifiedPortalUsersFromPortalsersDataWithRelativesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetUnifiedPortalUsersFromPortalUsersDataSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPortalUnfiedUsersForUsersDataSelect2(int tenantId, string searchTerm, int pageSize, int pageNumber, string lang);
       
        Task<Select2PagedResult> GetPortalUnfiedUsersForRegisterToPortalSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
