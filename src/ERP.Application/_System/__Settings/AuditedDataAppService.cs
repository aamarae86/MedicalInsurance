using Abp.Authorization;
using Abp.UI;
using ERP._System.__AidModule._Portal;
using ERP.Authorization.Users;
using ERP.Helpers.Core.__PostAudited;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace ERP._System.__Settings
{
    [AbpAuthorize]
    public class AuditedDataAppService : ERPAppServiceBase, IAuditedDataAppService
    {
        private readonly UserManager _userManager;
        private readonly IStoredUserInfoManager _storedUserInfoManager;

        public AuditedDataAppService(UserManager userManager, IStoredUserInfoManager storedUserInfoManager)
        {
            _userManager = userManager;
            _storedUserInfoManager = storedUserInfoManager;
        }

        public async Task<AuditedUserNamesDto> GetFullAuditedUserNameData(string permission, long? createdUserId, long? updateUserId,
            long? postedUserId, long? unPostedUserId)
        {
            var userPermissions = await _userManager.GetGrantedPermissionsAsync(await _userManager.GetUserByIdAsync((long)AbpSession.UserId));

            if (!userPermissions.Any(x => x.Name.Contains(permission))) throw new UserFriendlyException("Permission Not Valid !!!");

            var auditedUserNamesDto = new AuditedUserNamesDto();

            if (createdUserId.HasValue && createdUserId > 0)
            {
                try
                {
                    var currentUser = await _userManager.GetUserByIdAsync((long)createdUserId);

                    auditedUserNamesDto.CreatedBy = currentUser.Name;
                }
                catch (System.Exception)
                {
                    auditedUserNamesDto.CreatedBy = await GetUserInfo((long)createdUserId);
                    return auditedUserNamesDto;
                }
            }

            if (updateUserId.HasValue && updateUserId > 0)
            {
                try
                {
                    var currentUser = await _userManager.GetUserByIdAsync((long)updateUserId);

                    auditedUserNamesDto.UpdatedBy = currentUser.Name;
                }
                catch (System.Exception)
                {
                    auditedUserNamesDto.UpdatedBy = await GetUserInfo((long)updateUserId);
                    return auditedUserNamesDto;
                }
            }

            if (postedUserId.HasValue && postedUserId > 0)
            {
                try
                {
                    var currentUser = await _userManager.GetUserByIdAsync((long)postedUserId);

                    auditedUserNamesDto.PostedBy = currentUser.Name;
                }
                catch (System.Exception)
                {
                    auditedUserNamesDto.PostedBy = await GetUserInfo((long)postedUserId);
                    return auditedUserNamesDto;
                }
            }

            if (unPostedUserId.HasValue && unPostedUserId > 0)
            {
                try
                {
                    var currentUser = await _userManager.GetUserByIdAsync((long)unPostedUserId);

                    auditedUserNamesDto.UnPostedBy = currentUser.Name;
                }
                catch (System.Exception)
                {
                    auditedUserNamesDto.UnPostedBy = await GetUserInfo((long)unPostedUserId);
                    return auditedUserNamesDto;
                }
            }

            return auditedUserNamesDto;
        }

        private async Task<string> GetUserInfo(long userId)
        {
            try
            {
                var current = await _storedUserInfoManager.GetUserInfo(userId);

                return current?.Name ?? string.Empty;
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }
    }
}
