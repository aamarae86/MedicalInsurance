using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Services;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace ERP._System._Portal
{
    public interface IPortalUserRelativesManager : IDomainService
    {
        Task<PortalUserRelatives> CreateAsync(PortalUserRelatives input);

        Task<PortalUserRelatives> UpdateAsync(PortalUserRelatives input);

        Task<bool> DeleteAsync(Entity<long> input);

        Task<int> GetUserRelativesCount(long portalUserId);

    }
}
