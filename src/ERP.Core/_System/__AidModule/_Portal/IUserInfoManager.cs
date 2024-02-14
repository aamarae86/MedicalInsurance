using Abp.Domain.Services;
using ERP.Authorization.Users;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._Portal
{
    public interface IStoredUserInfoManager : IDomainService
    {
        Task<User> GetUserInfo(long userId);
    }
}
