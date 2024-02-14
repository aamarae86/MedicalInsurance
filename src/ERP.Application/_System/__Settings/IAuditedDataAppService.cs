using Abp.Application.Services;
using ERP.Helpers.Core.__PostAudited;
using System.Threading.Tasks;

namespace ERP._System.__Settings
{
    public interface IAuditedDataAppService : IApplicationService
    {
        Task<AuditedUserNamesDto> GetFullAuditedUserNameData(string permission, long? createdUserId, long? updateUserId, long? postedUserId, long? unPostedUserId);
    }
}
