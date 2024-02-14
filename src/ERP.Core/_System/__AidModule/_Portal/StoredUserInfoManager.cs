using ERP._System.__AidModule._Portal.Stored.Dto;
using ERP.Authorization.Users;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._Portal
{
    public class StoredUserInfoManager : IStoredUserInfoManager
    {
        private readonly IGetUserInfoRepository _getUserInfoRepository;

        public StoredUserInfoManager(IGetUserInfoRepository getUserInfoRepository)
        {
            _getUserInfoRepository = getUserInfoRepository;
        }

        public async Task<User> GetUserInfo(long userId)
        {
            var result = await _getUserInfoRepository.Execute(new GetUserInfoInput { userId = userId }, "GetUserInfo");

            return result.FirstOrDefault();
        }
    }
}
