using ERP._System.__AidModule._Portal._PortalFndUsers.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._Portal._PortalFndUsers.Proc
{
    public interface IGetFndUsersScreenDataRepository
        : IExecuteProcedure<PortalUser, long, IdLangInputDto, FndUsersScreenDataOutput>
    {
    }
}
