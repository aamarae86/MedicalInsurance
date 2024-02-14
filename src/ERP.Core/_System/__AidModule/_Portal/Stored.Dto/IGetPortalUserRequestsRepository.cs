using ERP.Authorization.Users;

namespace ERP._System.__AccountModule._Portal.Stored.Dto
{
    public interface IGetPortalUserRequestsRepository
          : IExecuteProcedure<PortalUser, long, UsersAidsInputDto, UsersAidsOutputDto>
    {
    }
}
