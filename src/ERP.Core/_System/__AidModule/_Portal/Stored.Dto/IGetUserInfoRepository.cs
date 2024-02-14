using ERP.Authorization.Users;

namespace ERP._System.__AidModule._Portal.Stored.Dto
{
    public interface IGetUserInfoRepository : IExecuteProcedure<PortalUser, long, GetUserInfoInput, User>
    {
    }
}
