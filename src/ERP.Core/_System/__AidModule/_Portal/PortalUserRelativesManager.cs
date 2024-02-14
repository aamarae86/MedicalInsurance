using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace ERP._System._Portal
{
    public class PortalUserRelativesManager : IPortalUserRelativesManager
    {
        private readonly IRepository<PortalUserRelatives, long> _repoPortalUserRelatives;
        public PortalUserRelativesManager(IRepository<PortalUserRelatives, long> repoPortalUserRelatives)
        {
            _repoPortalUserRelatives = repoPortalUserRelatives;
        }

        public async Task<PortalUserRelatives> CreateAsync(PortalUserRelatives input)
        {
            return await _repoPortalUserRelatives.InsertAsync(input);
        }

        public async Task<bool> DeleteAsync(Entity<long> input)
        {
            return await DeleteAsync(input);
        }

        public async Task<int> GetUserRelativesCount(long portalUserId)
            => await _repoPortalUserRelatives.CountAsync(z => z.PortalUserDataId == portalUserId);

        public async Task<PortalUserRelatives> UpdateAsync(PortalUserRelatives input)
        {
            return await _repoPortalUserRelatives.UpdateAsync(input);
        }
    }
}
