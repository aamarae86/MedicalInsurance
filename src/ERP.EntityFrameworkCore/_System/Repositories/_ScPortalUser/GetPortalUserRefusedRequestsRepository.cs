using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._Portal.Stored.Dto;
using ERP._System.__AidModule._Portal.Stored.Dto;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ScPortalUser
{
    public class GetPortalUserRefusedRequestsRepository :
                ERPProcedureRepositoryBase<PortalUser, long, UsersAidsInputDto, UsersRefusedRequestsOutputDto>, IGetPortalUserRefusedRequestsRepository
    {
        public GetPortalUserRefusedRequestsRepository(IDbContextProvider<ERPDbContext> dbContextProvider, IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}
