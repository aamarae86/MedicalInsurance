using ERP._System._Portal.Stored.Dto;
using ERP.Authorization.Users;

namespace ERP._System._Portal
{
    public interface IPortalUserDashboardRepository :
        IExecuteProcedure<PortalUser, long, DashboardDto, DashboardOutput>
    {
    }
}
