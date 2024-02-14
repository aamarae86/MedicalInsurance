using Abp.Domain.Repositories;
using ERP._System.__AidModule._PortalUserData;
using ERP.Authorization.Users;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._Portal._PortalFndUsers
{
    public class PortalUnifiedUsersManager : IPortalUnifiedUsersManager
    {
        private readonly IRepository<PortalUser, long> _repoUnifiedUsers;
        private readonly IRepository<PortalUserData, long> _repoPortalUserData;

        public PortalUnifiedUsersManager(IRepository<PortalUser, long> repoUnifiedUsers, IRepository<PortalUserData, long> repoPortalUserData)
        {
            _repoUnifiedUsers = repoUnifiedUsers;
            _repoPortalUserData = repoPortalUserData;
        }

        public async Task<Select2PagedResult> GetUnifiedPortalUsersFromPortalUsersDataSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPortalUserData.GetAllIncluding(x => x.PortalUser)
                 .Where(z => ((string.IsNullOrEmpty(searchTerm) || z.PortalUser.Name.Contains(searchTerm) || z.PortalUser.IdNumber.Contains(searchTerm))));

            var result = await data.OrderBy(q => q.PortalUser.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.PortalUserId, text = $"{z.PortalUser.Name}", altText = z.PortalUser.IdNumber }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetUnifiedPortalUsersFromPortalsersDataWithRelativesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPortalUserData.GetAllIncluding(x => x.PortalUser, x => x.Relatives)
                 .Where(z => ((string.IsNullOrEmpty(searchTerm) || z.PortalUser.Name.Contains(searchTerm) || z.PortalUser.IdNumber.Contains(searchTerm))));

            var result = await data.OrderBy(q => q.PortalUser.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.PortalUserId, text = $"{z.PortalUser.Name}", altText = z.Relatives.Count.ToString() }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPortalUnfiedUsersForUsersDataSelect2(int tenantId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var usersDataIds = _repoPortalUserData.GetAll().Select(z => z.PortalUserId);

            var data = _repoUnifiedUsers.GetAllIncluding()
                 .Where(z => ((string.IsNullOrEmpty(searchTerm) || z.Name.Contains(searchTerm) || z.IdNumber.Contains(searchTerm))));

            data = data.Where(z => !usersDataIds.Contains(z.Id));

            var result = await data.OrderBy(q => q.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.Name}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPortalUnfiedUsersForRegisterToPortalSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoUnifiedUsers.GetAllIncluding()
                 .Where(z => (z.UserId !=null) && ((string.IsNullOrEmpty(searchTerm) || z.Name.Contains(searchTerm) || z.IdNumber.Contains(searchTerm))));

            var result = await data.OrderBy(q => q.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = $"{z.Name}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
