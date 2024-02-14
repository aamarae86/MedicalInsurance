using ERP._System.__AccountModule._Portal.Stored.Dto;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._Portal.Stored.Dto
{
    public interface IGetPortalUserRefusedRequestsRepository
        : IExecuteProcedure<PortalUser, long, UsersAidsInputDto, UsersRefusedRequestsOutputDto>
    {
    }
}
