using System.Threading.Tasks;
using Abp.Domain.Services;
using ERP.Helpers.Core;

namespace ERP.Authorization.Users
{
    public interface IPortalUserManager : IDomainService
    {
        Task<PortalUser> CreateAsync(PortalUser portalUser);
        Task<Select2PagedResult> GetPortalUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetPortalUsersNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<bool> TestSendMail(string Email, string ResetLink);
    }
}
